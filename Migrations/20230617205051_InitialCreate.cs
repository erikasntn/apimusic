using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace musicapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Musicas",
                columns: new[] { "Id", "Album", "Artista", "Duracao", "Genero", "Titulo" },
                values: new object[,]
                {
                    { 1, "Speak Now", "Taylor Swift", new TimeSpan(0, 0, 5, 53, 0), "Country", "Enchanted" },
                    { 2, "Red Moon in Venus", "Kali Uchis", new TimeSpan(0, 0, 3, 7, 0), "R&B", "Moonlight" },
                    { 3, "QVVJFA?", "Baco Exu do Blues", new TimeSpan(0, 0, 3, 13, 0), "Hip-Hop", "20 ligações" },
                    { 4, "Dos Prédios Deluxe", "Veigh", new TimeSpan(0, 0, 2, 20, 0), "Trap", "Novo Balanço" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musicas");
        }
    }
}
