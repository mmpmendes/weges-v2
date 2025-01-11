using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadaTipologia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicencasERS_Ficheiros_FicheiroId",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "Tipologia",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Tipologia",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.AlterColumn<long>(
                name: "TipologiaId",
                schema: "weges",
                table: "Servicos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "Tipologias",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipologias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_TipologiaId",
                schema: "weges",
                table: "Servicos",
                column: "TipologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DirecoesClinicas_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas",
                column: "TipologiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirecoesClinicas_Tipologias_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas",
                column: "TipologiaId",
                principalSchema: "weges",
                principalTable: "Tipologias",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LicencasERS_Ficheiros_FicheiroId",
                schema: "weges",
                table: "LicencasERS",
                column: "FicheiroId",
                principalSchema: "weges",
                principalTable: "Ficheiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Tipologias_TipologiaId",
                schema: "weges",
                table: "Servicos",
                column: "TipologiaId",
                principalSchema: "weges",
                principalTable: "Tipologias",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirecoesClinicas_Tipologias_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropForeignKey(
                name: "FK_LicencasERS_Ficheiros_FicheiroId",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Tipologias_TipologiaId",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropTable(
                name: "Tipologias",
                schema: "weges");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_TipologiaId",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_DirecoesClinicas_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.AlterColumn<long>(
                name: "TipologiaId",
                schema: "weges",
                table: "Servicos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipologia",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipologia",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LicencasERS_Ficheiros_FicheiroId",
                schema: "weges",
                table: "LicencasERS",
                column: "FicheiroId",
                principalSchema: "weges",
                principalTable: "Ficheiros",
                principalColumn: "Id");
        }
    }
}
