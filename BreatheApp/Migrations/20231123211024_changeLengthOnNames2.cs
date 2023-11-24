using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreatheApp.Migrations
{
    /// <inheritdoc />
    public partial class changeLengthOnNames2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Doenca",
                type: "NVARCHAR2(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Doenca",
                type: "NVARCHAR2(280)",
                maxLength: 280,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Doenca",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Doenca",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(280)",
                oldMaxLength: 280);
        }
    }
}
