using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class MudancasNosFicheiros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localizacao",
                schema: "weges",
                table: "Ficheiros");

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginal",
                schema: "weges",
                table: "Ficheiros",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeOriginal",
                schema: "weges",
                table: "Ficheiros");

            migrationBuilder.AddColumn<string>(
                name: "Localizacao",
                schema: "weges",
                table: "Ficheiros",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true);
        }
    }
}
