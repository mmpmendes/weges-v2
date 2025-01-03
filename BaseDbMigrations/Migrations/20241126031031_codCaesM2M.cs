using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class codCaesM2M : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodCaeId",
                table: "Entidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodCaeId",
                table: "Entidades",
                type: "text",
                nullable: true);
        }
    }
}
