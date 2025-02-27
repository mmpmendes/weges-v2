using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidadeIdentificacao",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "ValidadeIdentificacao",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
