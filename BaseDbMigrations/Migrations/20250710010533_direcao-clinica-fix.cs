using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class direcaoclinicafix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_DirecoesClinicas_DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.AddColumn<long>(
                name: "EstabelecimentoId",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DirecoesClinicas_EstabelecimentoId",
                schema: "weges",
                table: "DirecoesClinicas",
                column: "EstabelecimentoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DirecoesClinicas_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "DirecoesClinicas",
                column: "EstabelecimentoId",
                principalSchema: "weges",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirecoesClinicas_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropIndex(
                name: "IX_DirecoesClinicas_EstabelecimentoId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.AddColumn<long>(
                name: "DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "DirecaoClinicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_DirecoesClinicas_DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "DirecaoClinicaId",
                principalSchema: "weges",
                principalTable: "DirecoesClinicas",
                principalColumn: "Id");
        }
    }
}
