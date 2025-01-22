using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class CartoesNipc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                schema: "weges",
                table: "Ficheiros",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "weges",
                table: "Ficheiros",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                schema: "weges",
                table: "Ficheiros",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoPrestador",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Denominacao",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "AnexoTipos",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexoTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorTipo",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anexos",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Submetido = table.Column<DateOnly>(type: "date", nullable: false),
                    Observacoes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    FicheiroId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoTipoId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anexos_AnexoTipos_AnexoTipoId",
                        column: x => x.AnexoTipoId,
                        principalSchema: "weges",
                        principalTable: "AnexoTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Anexos_Ficheiros_FicheiroId",
                        column: x => x.FicheiroId,
                        principalSchema: "weges",
                        principalTable: "Ficheiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    NrIdentificacao = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    InicioAtividade = table.Column<DateOnly>(type: "date", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    Especialidade = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    TotalHoras = table.Column<int>(type: "integer", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: false),
                    ServicoId = table.Column<long>(type: "bigint", nullable: false),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    ColaboradorTipoId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_ColaboradorTipo_ColaboradorTipoId",
                        column: x => x.ColaboradorTipoId,
                        principalSchema: "weges",
                        principalTable: "ColaboradorTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalSchema: "weges",
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstabelecimentoAnexos",
                schema: "weges",
                columns: table => new
                {
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    AnexoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoAnexos", x => new { x.EstabelecimentoId, x.AnexoId });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoAnexos_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalSchema: "weges",
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoAnexos_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formacao",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    HorasFormacao = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    ColaboradorId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formacao_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalSchema: "weges",
                        principalTable: "Colaborador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_AnexoTipoId",
                schema: "weges",
                table: "Anexos",
                column: "AnexoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_FicheiroId",
                schema: "weges",
                table: "Anexos",
                column: "FicheiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_ColaboradorTipoId",
                schema: "weges",
                table: "Colaborador",
                column: "ColaboradorTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_EstabelecimentoId",
                schema: "weges",
                table: "Colaborador",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_ServicoId",
                schema: "weges",
                table: "Colaborador",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoAnexos_AnexoId",
                schema: "weges",
                table: "EstabelecimentoAnexos",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Formacao_ColaboradorId",
                schema: "weges",
                table: "Formacao",
                column: "ColaboradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabelecimentoAnexos",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Formacao",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Anexos",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Colaborador",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "AnexoTipos",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "ColaboradorTipo",
                schema: "weges");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                schema: "weges",
                table: "Ficheiros",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "weges",
                table: "Ficheiros",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                schema: "weges",
                table: "Ficheiros",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoPrestador",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Denominacao",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);
        }
    }
}
