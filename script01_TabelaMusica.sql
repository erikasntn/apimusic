IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Musicas] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NOT NULL,
    [Artista] nvarchar(max) NOT NULL,
    [Album] nvarchar(max) NOT NULL,
    [Genero] nvarchar(max) NOT NULL,
    [Duracao] time NOT NULL,
    CONSTRAINT [PK_Musicas] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Album', N'Artista', N'Duracao', N'Genero', N'Titulo') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] ON;
INSERT INTO [Musicas] ([Id], [Album], [Artista], [Duracao], [Genero], [Titulo])
VALUES (1, N'Speak Now', N'Taylor Swift', '00:05:53', N'Country', N'Enchanted'),
(2, N'Red Moon in Venus', N'Kali Uchis', '00:03:07', N'R&B', N'Moonlight'),
(3, N'QVVJFA?', N'Baco Exu do Blues', '00:03:13', N'Hip-Hop', N'20 ligações'),
(4, N'Dos Prédios Deluxe', N'Veigh', '00:02:20', N'Trap', N'Novo Balanço');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Album', N'Artista', N'Duracao', N'Genero', N'Titulo') AND [object_id] = OBJECT_ID(N'[Musicas]'))
    SET IDENTITY_INSERT [Musicas] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230617205051_InitialCreate', N'7.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Musicas] ADD [UsuarioId] int NULL;
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

UPDATE [Musicas] SET [UsuarioId] = NULL
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Musicas] SET [UsuarioId] = NULL
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Musicas] SET [UsuarioId] = NULL
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Musicas] SET [UsuarioId] = NULL
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Musicas_UsuarioId] ON [Musicas] ([UsuarioId]);
GO

ALTER TABLE [Musicas] ADD CONSTRAINT [FK_Musicas_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230621002104_MigracaoAlteracaoClasses', N'7.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Usuarios].[Senha]', N'SenhadString', N'COLUMN';
GO

ALTER TABLE [Usuarios] ADD [SenhadHash] varbinary(max) NOT NULL DEFAULT 0x;
GO

ALTER TABLE [Usuarios] ADD [SenhadSalt] varbinary(max) NOT NULL DEFAULT 0x;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Nome', N'SenhadHash', N'SenhadSalt', N'SenhadString') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Email], [Nome], [SenhadHash], [SenhadSalt], [SenhadString])
VALUES (1, N'Erika@gmail.com', N'Erika', 0xB5D7DE56F42C6271B0EEC1CA79DEA6F1A7A2FA727390F2A51908CEBA2109C1E1FEEE5F12E17CC6D86729D9F4A0997FB0C1F5AB9BEF3F6C28D9D06DE498AC4D84, 0x3CA83AABFEC62C65046C556A1B92A8EC998D0D18A9C03FA31724A452289FF6308E9D1E95EB3D225291438306283EF47F080ED7C072AF2DACFB8870EE209714959D99AEB5877DD18AAF08F385AAA4D4DD6408F6CBF53A1008C492774777DB814E0C18C58AB4BF8229B3EA350376C352310EAF951BE07662FCB1A889B9CDACC6B7, N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Nome', N'SenhadHash', N'SenhadSalt', N'SenhadString') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230621015024_MigracaoUsuarios', N'7.0.7');
GO

COMMIT;
GO

