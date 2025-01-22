using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AlvarasMedidasANPCParecerANPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabelecimentoAnexos",
                schema: "weges");

            migrationBuilder.CreateTable(
                name: "EstabelecimentoAlvaras",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoAlvaras", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoAlvaras_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoAlvaras_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoCartoesNipc",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoCartoesNipc", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoCartoesNipc_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoCartoesNipc_Estabelecimentos_Estabelecimento~",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoMedidasANPC",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoMedidasANPC", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoMedidasANPC_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoMedidasANPC_Estabelecimentos_Estabelecimento~",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoParecerANPC",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoParecerANPC", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoParecerANPC_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoParecerANPC_Estabelecimentos_Estabelecimento~",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoAlvaras_AnexoId",
                schema: "weges",
                table: "EstabelecimentoAlvaras",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoCartoesNipc_AnexoId",
                schema: "weges",
                table: "EstabelecimentoCartoesNipc",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoMedidasANPC_AnexoId",
                schema: "weges",
                table: "EstabelecimentoMedidasANPC",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoParecerANPC_AnexoId",
                schema: "weges",
                table: "EstabelecimentoParecerANPC",
                column: "AnexoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabelecimentoAlvaras",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "EstabelecimentoCartoesNipc",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "EstabelecimentoMedidasANPC",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "EstabelecimentoParecerANPC",
                schema: "weges");

            migrationBuilder.CreateTable(
                name: "EstabelecimentoAnexos",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoAnexos", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoAnexos_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoAnexos_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoAnexos_AnexoId",
                schema: "weges",
                table: "EstabelecimentoAnexos",
                column: "AnexoId");
        }
    }
}
