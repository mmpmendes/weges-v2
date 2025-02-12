using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AnexosFicheiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "weges",
                table: "DirecoesClinicas",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "weges",
                table: "DirecoesClinicas",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "weges",
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "weges",
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 2L);

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

            migrationBuilder.DropColumn(
                name: "Tipologia",
                schema: "weges",
                table: "DirecoesClinicas");

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
                name: "ModifiedBy",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                defaultValue: "system-usr",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "Estabelecimentos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                defaultValue: "system-usr",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "Estabelecimentos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<long>(
                name: "AlvaraId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CartaoNipcId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DireitosDeveresId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FicheirosAnexarId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LicenciamentoRegistoLegalId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ListaVerificacaoId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MedidaAnpcId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParecerAnpcId",
                schema: "weges",
                table: "Estabelecimentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                defaultValue: "system-usr",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                defaultValue: "system-usr",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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
                name: "Ficheiros",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Localizacao = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Tipo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficheiros", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Anexos",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_Anexos_Estabelecimentos_Id",
                        column: x => x.Id,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anexos_Ficheiros_FicheiroId",
                        column: x => x.FicheiroId,
                        principalSchema: "weges",
                        principalTable: "Ficheiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificadosERS",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Periodo = table.Column<string>(type: "text", nullable: true),
                    NrCertificado = table.Column<string>(type: "text", nullable: true),
                    DataSubmissao = table.Column<DateOnly>(type: "date", nullable: true),
                    DataExpiracao = table.Column<DateOnly>(type: "date", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    DataExpiracaoTaxa = table.Column<DateOnly>(type: "date", nullable: true),
                    DataPagamentoTaxa = table.Column<DateOnly>(type: "date", nullable: true),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    FicheiroId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadosERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificadosERS_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificadosERS_Ficheiros_FicheiroId",
                        column: x => x.FicheiroId,
                        principalSchema: "weges",
                        principalTable: "Ficheiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LicencasERS",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NrLicenca = table.Column<string>(type: "text", nullable: true),
                    DataSubmissao = table.Column<DateOnly>(type: "date", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    FicheiroId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicencasERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicencasERS_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicencasERS_Ficheiros_FicheiroId",
                        column: x => x.FicheiroId,
                        principalSchema: "weges",
                        principalTable: "Ficheiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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
                    Horario = table.Column<string>(type: "text", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    TipologiaId = table.Column<long>(type: "bigint", nullable: true),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Tipologias_TipologiaId",
                        column: x => x.TipologiaId,
                        principalSchema: "weges",
                        principalTable: "Tipologias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
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
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_ColaboradorTipo_ColaboradorTipoId",
                        column: x => x.ColaboradorTipoId,
                        principalSchema: "weges",
                        principalTable: "ColaboradorTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalSchema: "weges",
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalSchema: "weges",
                        principalTable: "Servicos",
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
                        name: "FK_Formacao_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalSchema: "weges",
                        principalTable: "Colaboradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_AlvaraId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "AlvaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_CartaoNipcId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "CartaoNipcId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_DireitosDeveresId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "DireitosDeveresId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_FicheirosAnexarId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "FicheirosAnexarId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_ListaVerificacaoId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "ListaVerificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_MedidaAnpcId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "MedidaAnpcId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_ParecerAnpcId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "ParecerAnpcId");

            migrationBuilder.CreateIndex(
                name: "IX_DirecoesClinicas_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas",
                column: "TipologiaId");

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
                name: "IX_CertificadosERS_EstabelecimentoId",
                schema: "weges",
                table: "CertificadosERS",
                column: "EstabelecimentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CertificadosERS_FicheiroId",
                schema: "weges",
                table: "CertificadosERS",
                column: "FicheiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_ColaboradorTipoId",
                schema: "weges",
                table: "Colaboradores",
                column: "ColaboradorTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_EstabelecimentoId",
                schema: "weges",
                table: "Colaboradores",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_ServicoId",
                schema: "weges",
                table: "Colaboradores",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Formacao_ColaboradorId",
                schema: "weges",
                table: "Formacao",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_LicencasERS_EstabelecimentoId",
                schema: "weges",
                table: "LicencasERS",
                column: "EstabelecimentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicencasERS_FicheiroId",
                schema: "weges",
                table: "LicencasERS",
                column: "FicheiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_TipologiaId",
                schema: "weges",
                table: "Servicos",
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
                name: "FK_Estabelecimentos_Anexos_AlvaraId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "AlvaraId",
                principalSchema: "weges",
                principalTable: "Anexos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Anexos_CartaoNipcId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "CartaoNipcId",
                principalSchema: "weges",
                principalTable: "Anexos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Anexos_DireitosDeveresId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "DireitosDeveresId",
                principalSchema: "weges",
                principalTable: "Anexos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Anexos_FicheirosAnexarId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "FicheirosAnexarId",
                principalSchema: "weges",
                principalTable: "Anexos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Anexos_ListaVerificacaoId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "ListaVerificacaoId",
                principalSchema: "weges",
                principalTable: "Anexos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Anexos_MedidaAnpcId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "MedidaAnpcId",
                principalSchema: "weges",
                principalTable: "Anexos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Anexos_ParecerAnpcId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "ParecerAnpcId",
                principalSchema: "weges",
                principalTable: "Anexos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirecoesClinicas_Tipologias_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Anexos_AlvaraId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Anexos_CartaoNipcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Anexos_DireitosDeveresId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Anexos_FicheirosAnexarId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Anexos_ListaVerificacaoId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Anexos_MedidaAnpcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Anexos_ParecerAnpcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Anexos",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "CertificadosERS",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Formacao",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "LicencasERS",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "AnexoTipos",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Colaboradores",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Ficheiros",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "ColaboradorTipo",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Servicos",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Tipologias",
                schema: "weges");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_AlvaraId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_CartaoNipcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_DireitosDeveresId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_FicheirosAnexarId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_ListaVerificacaoId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_MedidaAnpcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_ParecerAnpcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_DirecoesClinicas_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "AlvaraId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "CartaoNipcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "DireitosDeveresId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "FicheirosAnexarId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "LicenciamentoRegistoLegalId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "ListaVerificacaoId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "MedidaAnpcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "ParecerAnpcId",
                schema: "weges",
                table: "Estabelecimentos");

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
                name: "ModifiedBy",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "system-usr");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "Estabelecimentos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

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

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "system-usr");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "Estabelecimentos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

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

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "system-usr");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "system-usr");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "Tipologia",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "weges",
                table: "DirecoesClinicas",
                columns: new[] { "Id", "Cargo", "Cedula", "Created", "CreatedBy", "Especialidade", "EspecialidadeId", "EstabelecimentoId", "Identificacao", "Modified", "ModifiedBy", "Nome", "Observacoes", "Ordem", "Tipologia", "TipologiaId", "ValidadeIdentificacao" },
                values: new object[,]
                {
                    { 1L, "Cargo 1", "Cedula 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Especialidade 1", 1L, 1L, "Identificacao 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nome 1", "Observacoes 1", "Ordem 1", "Tipologia 1", 1L, new DateOnly(2023, 2, 20) },
                    { 2L, "Cargo 2", "Cedula 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Especialidade 2", 2L, 2L, "Identificacao 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nome 2", "Observacoes 2", "Ordem 2", "Tipologia 2", 2L, new DateOnly(2023, 2, 20) }
                });

            migrationBuilder.InsertData(
                schema: "weges",
                table: "Entidades",
                columns: new[] { "Id", "Denominacao", "Email", "EmailNotificacoesERS", "EmailNotificacoesGerais", "Morada", "NifNipc", "NrERS", "Sigla", "Telefone" },
                values: new object[,]
                {
                    { 1L, "Entidade 1", "emailteste@email.email", "emailnotificacoes@email.email", "emailnotificacoes@email.email", "Rua do Teste 1", "123123123", "A-1234", "ent1", "921111111" },
                    { 2L, "Entidade 2", "emailteste@email.email", "emailnotificacoes@email.email", "emailnotificacoes@email.email", "Rua do Teste 2", "123123123", "A-1234", "ent2", "921111111" }
                });

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
    }
}
