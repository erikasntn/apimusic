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

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [SenhadHash] = 0x47389CB9D3CEB34903E0C3D97B4D6437D489CEBBF5A71F8E6E8C0D60082EEFA98A7AA2358C45AC5E209E09BBBCD15BB520D18CE90A2B24B2489EB8D7C75C816D, [SenhadSalt] = 0xA340AA31FB3004BF0DCDDC37DCB7759BB56BEA5A1BC9E1FDC4D20C2CB7AB5E45BEDC6C43B0E7157FD82391DA11894C647F05ABA584CEDB8BCC2715004347DED509935A11CFD4548520C5449575E64152E63DF9C01FA64408C86C5F6762B04C6CB2E1B9414BB4A88ED33A4A64FAA1B2768461DBEEA41355CD2D721AE2E6B6A3A4
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230621180450_MigrationPermitirNulo', N'7.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'SenhadString');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [SenhadString] nvarchar(max) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'SenhadSalt');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [SenhadSalt] varbinary(max) NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'SenhadHash');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [SenhadHash] varbinary(max) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'Nome');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [Nome] nvarchar(max) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'Email');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [Email] nvarchar(max) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Musicas]') AND [c].[name] = N'Titulo');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Musicas] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Musicas] ALTER COLUMN [Titulo] nvarchar(max) NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Musicas]') AND [c].[name] = N'Genero');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Musicas] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Musicas] ALTER COLUMN [Genero] nvarchar(max) NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Musicas]') AND [c].[name] = N'Artista');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Musicas] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Musicas] ALTER COLUMN [Artista] nvarchar(max) NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Musicas]') AND [c].[name] = N'Album');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Musicas] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Musicas] ALTER COLUMN [Album] nvarchar(max) NULL;
GO

UPDATE [Usuarios] SET [SenhadHash] = 0xA86C20AC7F1BFD37AA55EC8C8F2B8865FEEE5DD15E8894127629294B5BB2669B1F93438A51FD9CDD999D84ABD132B987B37A570C8EC33AA314F47511BFDE2AAE, [SenhadSalt] = 0xABDA14644F5F3DD7D807843AF0B9906064DD2D74BA93D2903F78F25C24AC60BBC5229DD28F0D9C78BAF0930E366033A72B9FFF1C6B838F11B4C6A99C1C8E4377379BC19872B3A7019F944D7DCC892918860065B2F0DEC64FBF0EE6E71CE71449DCBB1AEF14DBCF41F57E4F4585AFD3A9A778F8864A0A2D8DC12FCB13F359CD0A
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230628003333_Final', N'7.0.7');
GO

COMMIT;
GO

