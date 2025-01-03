using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedEstabsExemplo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "weges",
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Denominacao", "Sigla" },
                values: new object[] { "Entidade 1", "ent1" });

            migrationBuilder.UpdateData(
                schema: "weges",
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Denominacao", "Sigla" },
                values: new object[] { "Entidade 2", "ent2" });

            migrationBuilder.InsertData(
                schema: "weges",
                table: "Estabelecimentos",
                columns: new[] { "Id", "Created", "CreatedBy", "Denominacao", "Email", "InicioAtividade", "Modified", "ModifiedBy", "Morada", "Sigla", "Telefone", "TipoPrestador" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Estabelecimento 1", "email@email.email", new DateOnly(2020, 2, 20), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "estab 1 morada", "estab1", "291111111", "Tipo de Prestador" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Estabelecimento 2", "email@email.email", new DateOnly(2023, 2, 20), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "estab 2 morada", "estab2", "291111112", "Tipo de Prestador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "weges",
                table: "Estabelecimentos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "weges",
                table: "Estabelecimentos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                schema: "weges",
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Denominacao", "Sigla" },
                values: new object[] { "Teste 1", "TsT1" });

            migrationBuilder.UpdateData(
                schema: "weges",
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Denominacao", "Sigla" },
                values: new object[] { "Teste 2", "TsT2" });
        }
    }
}
