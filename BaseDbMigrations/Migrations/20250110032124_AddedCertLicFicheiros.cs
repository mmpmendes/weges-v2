using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedCertLicFicheiros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ficheiros",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Localizacao = table.Column<string>(type: "text", nullable: true),
                    Tipo = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficheiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificadosERS",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Periodo = table.Column<string>(type: "text", nullable: true),
                    NrCertificado = table.Column<string>(type: "text", nullable: true),
                    DataSubmissao = table.Column<DateOnly>(type: "date", nullable: true),
                    DataExpiracao = table.Column<DateOnly>(type: "date", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    DataExpiracaoTaxa = table.Column<DateOnly>(type: "date", nullable: true),
                    DataPagamentoTaxa = table.Column<DateOnly>(type: "date", nullable: true),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    FicheiroId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadosERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificadosERS_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificadosERS_Ficheiros_FicheiroId",
                        column: x => x.FicheiroId,
                        principalSchema: "weges",
                        principalTable: "Ficheiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LicencasERS",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Periodo = table.Column<string>(type: "text", nullable: true),
                    NrLicenca = table.Column<string>(type: "text", nullable: true),
                    DataSubmissao = table.Column<DateOnly>(type: "date", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    FicheiroId = table.Column<long>(type: "bigint", nullable: true),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicencasERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicencasERS_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicencasERS_Ficheiros_FicheiroId",
                        column: x => x.FicheiroId,
                        principalSchema: "weges",
                        principalTable: "Ficheiros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificadosERS_EstabelecimentoId",
                schema: "weges",
                table: "CertificadosERS",
                column: "EstabelecimentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CertificadosERS_FicheiroId",
                schema: "weges",
                table: "CertificadosERS",
                column: "FicheiroId");

            migrationBuilder.CreateIndex(
                name: "IX_LicencasERS_EstabelecimentoId",
                schema: "weges",
                table: "LicencasERS",
                column: "EstabelecimentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicencasERS_FicheiroId",
                schema: "weges",
                table: "LicencasERS",
                column: "FicheiroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificadosERS",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "LicencasERS",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Ficheiros",
                schema: "weges");
        }
    }
}
