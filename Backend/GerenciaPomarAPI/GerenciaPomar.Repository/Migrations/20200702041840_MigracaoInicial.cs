using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaPomar.Repository.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "GruposArvores",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposArvores", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Arvores",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DataPlantio = table.Column<DateTime>(nullable: false),
                    CodigoEspecie = table.Column<Guid>(nullable: false),
                    GrupoArvoreCodigo = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arvores", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Arvores_Especies_CodigoEspecie",
                        column: x => x.CodigoEspecie,
                        principalTable: "Especies",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arvores_GruposArvores_GrupoArvoreCodigo",
                        column: x => x.GrupoArvoreCodigo,
                        principalTable: "GruposArvores",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colheitas",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Informacoes = table.Column<string>(nullable: true),
                    DataColheita = table.Column<DateTime>(nullable: false),
                    PesoBruto = table.Column<double>(nullable: false),
                    CodigoArvore = table.Column<Guid>(nullable: false),
                    CodigoGrupoArvore = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colheitas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Colheitas_Arvores_CodigoArvore",
                        column: x => x.CodigoArvore,
                        principalTable: "Arvores",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colheitas_GruposArvores_CodigoGrupoArvore",
                        column: x => x.CodigoGrupoArvore,
                        principalTable: "GruposArvores",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arvores_CodigoEspecie",
                table: "Arvores",
                column: "CodigoEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Arvores_GrupoArvoreCodigo",
                table: "Arvores",
                column: "GrupoArvoreCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Colheitas_CodigoArvore",
                table: "Colheitas",
                column: "CodigoArvore");

            migrationBuilder.CreateIndex(
                name: "IX_Colheitas_CodigoGrupoArvore",
                table: "Colheitas",
                column: "CodigoGrupoArvore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colheitas");

            migrationBuilder.DropTable(
                name: "Arvores");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "GruposArvores");
        }
    }
}
