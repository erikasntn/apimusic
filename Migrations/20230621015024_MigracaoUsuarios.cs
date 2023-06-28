using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace musicapi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "SenhadString");

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhadHash",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhadSalt",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "SenhadHash", "SenhadSalt", "SenhadString" },
                values: new object[] { 1, "Erika@gmail.com", "Erika", new byte[] { 181, 215, 222, 86, 244, 44, 98, 113, 176, 238, 193, 202, 121, 222, 166, 241, 167, 162, 250, 114, 115, 144, 242, 165, 25, 8, 206, 186, 33, 9, 193, 225, 254, 238, 95, 18, 225, 124, 198, 216, 103, 41, 217, 244, 160, 153, 127, 176, 193, 245, 171, 155, 239, 63, 108, 40, 217, 208, 109, 228, 152, 172, 77, 132 }, new byte[] { 60, 168, 58, 171, 254, 198, 44, 101, 4, 108, 85, 106, 27, 146, 168, 236, 153, 141, 13, 24, 169, 192, 63, 163, 23, 36, 164, 82, 40, 159, 246, 48, 142, 157, 30, 149, 235, 61, 34, 82, 145, 67, 131, 6, 40, 62, 244, 127, 8, 14, 215, 192, 114, 175, 45, 172, 251, 136, 112, 238, 32, 151, 20, 149, 157, 153, 174, 181, 135, 125, 209, 138, 175, 8, 243, 133, 170, 164, 212, 221, 100, 8, 246, 203, 245, 58, 16, 8, 196, 146, 119, 71, 119, 219, 129, 78, 12, 24, 197, 138, 180, 191, 130, 41, 179, 234, 53, 3, 118, 195, 82, 49, 14, 175, 149, 27, 224, 118, 98, 252, 177, 168, 137, 185, 205, 172, 198, 183 }, "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SenhadHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SenhadSalt",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "SenhadString",
                table: "Usuarios",
                newName: "Senha");
        }
    }
}
