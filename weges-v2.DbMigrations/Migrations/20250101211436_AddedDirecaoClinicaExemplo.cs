using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace weges_v2.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedDirecaoClinicaExemplo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirecoesClinicas",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cargo = table.Column<string>(type: "text", nullable: true),
                    Identificacao = table.Column<string>(type: "text", nullable: true),
                    ValidadeIdentificacao = table.Column<DateOnly>(type: "date", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: true),
                    Ordem = table.Column<string>(type: "text", nullable: true),
                    Especialidade = table.Column<string>(type: "text", nullable: true),
                    EspecialidadeId = table.Column<long>(type: "bigint", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    TipologiaId = table.Column<long>(type: "bigint", nullable: false),
                    Tipologia = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirecoesClinicas", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "weges",
                table: "DirecoesClinicas",
                columns: new[] { "Id", "Cargo", "Cedula", "Created", "CreatedBy", "Especialidade", "EspecialidadeId", "EstabelecimentoId", "Identificacao", "Modified", "ModifiedBy", "Nome", "Observacoes", "Ordem", "Tipologia", "TipologiaId", "ValidadeIdentificacao" },
                values: new object[,]
                {
                    { 1L, "Cargo 1", "Cedula 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Especialidade 1", 1L, 1L, "Identificacao 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nome 1", "Observacoes 1", "Ordem 1", "Tipologia 1", 1L, new DateOnly(2023, 2, 20) },
                    { 2L, "Cargo 2", "Cedula 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Especialidade 2", 2L, 2L, "Identificacao 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nome 2", "Observacoes 2", "Ordem 2", "Tipologia 2", 2L, new DateOnly(2023, 2, 20) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirecoesClinicas",
                schema: "weges");
        }
    }
}
