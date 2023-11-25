using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreatheApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOnEverything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Usuario",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Diagnostico",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PontoDeReferencia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LogradouroId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Endereco_Logradouro_LogradouroId",
                        column: x => x.LogradouroId,
                        principalTable: "Logradouro",
                        principalColumn: "LogradouroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_LogradouroId",
                table: "Endereco",
                column: "LogradouroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Logradouro");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Diagnostico");
        }
    }
}
