using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class RestOfAnexosList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstabelecimentoDireitosDeveres",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoDireitosDeveres", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoDireitosDeveres_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoDireitosDeveres_Estabelecimentos_Estabelecim~",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoFicheirosAnexar",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoFicheirosAnexar", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoFicheirosAnexar_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoFicheirosAnexar_Estabelecimentos_Estabelecim~",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoLicenciamentoRegistoLegal",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoLicenciamentoRegistoLegal", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoLicenciamentoRegistoLegal_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoLicenciamentoRegistoLegal_Estabelecimentos_E~",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoListaVerificacao",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoListaVerificacao", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoListaVerificacao_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoListaVerificacao_Estabelecimentos_Estabeleci~",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoDireitosDeveres_AnexoId",
                schema: "weges",
                table: "EstabelecimentoDireitosDeveres",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoFicheirosAnexar_AnexoId",
                schema: "weges",
                table: "EstabelecimentoFicheirosAnexar",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoLicenciamentoRegistoLegal_AnexoId",
                schema: "weges",
                table: "EstabelecimentoLicenciamentoRegistoLegal",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoListaVerificacao_AnexoId",
                schema: "weges",
                table: "EstabelecimentoListaVerificacao",
                column: "AnexoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabelecimentoDireitosDeveres",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "EstabelecimentoFicheirosAnexar",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "EstabelecimentoLicenciamentoRegistoLegal",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "EstabelecimentoListaVerificacao",
                schema: "weges");
        }
    }
}
