﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace musicapi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoAlteracaoClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Musicas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 2,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 3,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Musicas",
                keyColumn: "Id",
                keyValue: 4,
                column: "UsuarioId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_UsuarioId",
                table: "Musicas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_Usuarios_UsuarioId",
                table: "Musicas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_Usuarios_UsuarioId",
                table: "Musicas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Musicas_UsuarioId",
                table: "Musicas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Musicas");
        }
    }
}
