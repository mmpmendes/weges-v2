using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weges_v2.DbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class codCaesM2M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodCaes_Entidades_EntidadeId",
                table: "CodCaes");

            migrationBuilder.DropIndex(
                name: "IX_CodCaes_EntidadeId",
                table: "CodCaes");

            migrationBuilder.DropColumn(
                name: "EntidadeId",
                table: "CodCaes");

            migrationBuilder.CreateTable(
                name: "CodCaeEntidade",
                columns: table => new
                {
                    CodCaesId = table.Column<long>(type: "bigint", nullable: false),
                    EntidadesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodCaeEntidade", x => new { x.CodCaesId, x.EntidadesId });
                    table.ForeignKey(
                        name: "FK_CodCaeEntidade_CodCaes_CodCaesId",
                        column: x => x.CodCaesId,
                        principalTable: "CodCaes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CodCaeEntidade_Entidades_EntidadesId",
                        column: x => x.EntidadesId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodCaeEntidade_EntidadesId",
                table: "CodCaeEntidade",
                column: "EntidadesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodCaeEntidade");

            migrationBuilder.AddColumn<long>(
                name: "EntidadeId",
                table: "CodCaes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CodCaes_EntidadeId",
                table: "CodCaes",
                column: "EntidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CodCaes_Entidades_EntidadeId",
                table: "CodCaes",
                column: "EntidadeId",
                principalTable: "Entidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
