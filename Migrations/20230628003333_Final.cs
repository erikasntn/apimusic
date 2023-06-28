using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace musicapi.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SenhadString",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "SenhadSalt",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "SenhadHash",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Artista",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Album",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SenhadHash", "SenhadSalt" },
                values: new object[] { new byte[] { 168, 108, 32, 172, 127, 27, 253, 55, 170, 85, 236, 140, 143, 43, 136, 101, 254, 238, 93, 209, 94, 136, 148, 18, 118, 41, 41, 75, 91, 178, 102, 155, 31, 147, 67, 138, 81, 253, 156, 221, 153, 157, 132, 171, 209, 50, 185, 135, 179, 122, 87, 12, 142, 195, 58, 163, 20, 244, 117, 17, 191, 222, 42, 174 }, new byte[] { 171, 218, 20, 100, 79, 95, 61, 215, 216, 7, 132, 58, 240, 185, 144, 96, 100, 221, 45, 116, 186, 147, 210, 144, 63, 120, 242, 92, 36, 172, 96, 187, 197, 34, 157, 210, 143, 13, 156, 120, 186, 240, 147, 14, 54, 96, 51, 167, 43, 159, 255, 28, 107, 131, 143, 17, 180, 198, 169, 156, 28, 142, 67, 119, 55, 155, 193, 152, 114, 179, 167, 1, 159, 148, 77, 125, 204, 137, 41, 24, 134, 0, 101, 178, 240, 222, 198, 79, 191, 14, 230, 231, 28, 231, 20, 73, 220, 187, 26, 239, 20, 219, 207, 65, 245, 126, 79, 69, 133, 175, 211, 169, 167, 120, 248, 134, 74, 10, 45, 141, 193, 47, 203, 19, 243, 89, 205, 10 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SenhadString",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "SenhadSalt",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "SenhadHash",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Artista",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Album",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SenhadHash", "SenhadSalt" },
                values: new object[] { new byte[] { 71, 56, 156, 185, 211, 206, 179, 73, 3, 224, 195, 217, 123, 77, 100, 55, 212, 137, 206, 187, 245, 167, 31, 142, 110, 140, 13, 96, 8, 46, 239, 169, 138, 122, 162, 53, 140, 69, 172, 94, 32, 158, 9, 187, 188, 209, 91, 181, 32, 209, 140, 233, 10, 43, 36, 178, 72, 158, 184, 215, 199, 92, 129, 109 }, new byte[] { 163, 64, 170, 49, 251, 48, 4, 191, 13, 205, 220, 55, 220, 183, 117, 155, 181, 107, 234, 90, 27, 201, 225, 253, 196, 210, 12, 44, 183, 171, 94, 69, 190, 220, 108, 67, 176, 231, 21, 127, 216, 35, 145, 218, 17, 137, 76, 100, 127, 5, 171, 165, 132, 206, 219, 139, 204, 39, 21, 0, 67, 71, 222, 213, 9, 147, 90, 17, 207, 212, 84, 133, 32, 197, 68, 149, 117, 230, 65, 82, 230, 61, 249, 192, 31, 166, 68, 8, 200, 108, 95, 103, 98, 176, 76, 108, 178, 225, 185, 65, 75, 180, 168, 142, 211, 58, 74, 100, 250, 161, 178, 118, 132, 97, 219, 238, 164, 19, 85, 205, 45, 114, 26, 226, 230, 182, 163, 164 } });
        }
    }
}
