using Microsoft.EntityFrameworkCore.Migrations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedServicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicos",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: true),
                    Responsavel = table.Column<string>(type: "text", nullable: true),
                    TipologiaId = table.Column<long>(type: "bigint", nullable: false),
                    Horario = table.Column<string>(type: "text", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    Tipologia = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "weges",
                table: "Servicos",
                columns: new[] { "Id", "Created", "CreatedBy", "DataInicio", "EstabelecimentoId", "Horario", "Modified", "ModifiedBy", "Nome", "Observacoes", "Responsavel", "Tipologia", "TipologiaId" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateOnly(2023, 2, 20), 1L, "Horario 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Servico 1", "Observacoes 1", "Responsavel 1", "Tipologia 1", 1L },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateOnly(2023, 2, 20), 2L, "Horario 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Servico 2", "Observacoes 2", "Responsavel 2", "Tipologia 2", 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicos",
                schema: "weges");
        }
    }
}
