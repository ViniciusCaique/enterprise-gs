using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreatheApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOnEverything5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Logradouro_LogradouroId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Logradouro");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_LogradouroId",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "LogradouroId",
                table: "Endereco",
                newName: "Numero");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Usuario",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Endereco",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Endereco",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Endereco",
                newName: "LogradouroId");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Usuario",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Logradouro",
                columns: table => new
                {
                    LogradouroId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logradouro", x => x.LogradouroId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_LogradouroId",
                table: "Endereco",
                column: "LogradouroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Logradouro_LogradouroId",
                table: "Endereco",
                column: "LogradouroId",
                principalTable: "Logradouro",
                principalColumn: "LogradouroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
