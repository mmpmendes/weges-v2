using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace weges_v2.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Entidades",
                columns: new[] { "Id", "Denominacao", "Email", "EmailNotificacoesERS", "EmailNotificacoesGerais", "Morada", "NifNipc", "NrERS", "Sigla", "Telefone" },
                values: new object[,]
                {
                    { 1L, "Teste 1", "emailteste@email.email", "emailnotificacoes@email.email", "emailnotificacoes@email.email", "Rua do Teste 1", "123123123", "A-1234", "TsT1", "921111111" },
                    { 2L, "Teste 2", "emailteste@email.email", "emailnotificacoes@email.email", "emailnotificacoes@email.email", "Rua do Teste 2", "123123123", "A-1234", "TsT2", "921111111" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
