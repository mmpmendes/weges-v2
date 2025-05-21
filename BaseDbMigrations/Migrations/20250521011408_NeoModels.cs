using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class NeoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificadosERS_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificadosERS_Ficheiros_FicheiroId",
                schema: "weges",
                table: "CertificadosERS");

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

            migrationBuilder.DropForeignKey(
                name: "FK_LicencasERS_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropForeignKey(
                name: "FK_LicencasERS_Ficheiros_FicheiroId",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Tipologias_TipologiaId",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropTable(
                name: "Anexos",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "CodCaeEntidade",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Formacao",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Tipologias",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "AnexoTipos",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Ficheiros",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "CodCaes",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Colaboradores",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "ColaboradorTipo",
                schema: "weges");

            migrationBuilder.DropIndex(
                name: "IX_LicencasERS_EstabelecimentoId",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropIndex(
                name: "IX_LicencasERS_FicheiroId",
                schema: "weges",
                table: "LicencasERS");

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
                name: "IX_DirecoesClinicas_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropIndex(
                name: "IX_CertificadosERS_EstabelecimentoId",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropIndex(
                name: "IX_CertificadosERS_FicheiroId",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Responsavel",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "DataSubmissao",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "FicheiroId",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "NrLicenca",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "AlvaraId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "CartaoNipcId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
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
                name: "Modified",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "Denominacao",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "EmailNotificacoesERS",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "EmailNotificacoesGerais",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "Morada",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "NifNipc",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "NrERS",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "Sigla",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "Telefone",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "Cargo",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "Cedula",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "EspecialidadeId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "EstabelecimentoId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "Identificacao",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "ValidadeIdentificacao",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "DataExpiracao",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "DataExpiracaoTaxa",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "DataPagamentoTaxa",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "DataSubmissao",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "FicheiroId",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "NrCertificado",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "Periodo",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.RenameColumn(
                name: "TipologiaId",
                schema: "weges",
                table: "Servicos",
                newName: "LicencaId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicos_TipologiaId",
                schema: "weges",
                table: "Servicos",
                newName: "IX_Servicos_LicencaId");

            migrationBuilder.RenameColumn(
                name: "ParecerAnpcId",
                schema: "weges",
                table: "Estabelecimentos",
                newName: "DirecaoClinicaId");

            migrationBuilder.RenameColumn(
                name: "InicioAtividade",
                schema: "weges",
                table: "Estabelecimentos",
                newName: "DataInicioAtividade");

            migrationBuilder.RenameIndex(
                name: "IX_Estabelecimentos_ParecerAnpcId",
                schema: "weges",
                table: "Estabelecimentos",
                newName: "IX_Estabelecimentos_DirecaoClinicaId");

            migrationBuilder.AlterColumn<string>(
                name: "Horario",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CertificadoId",
                schema: "weges",
                table: "Servicos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeclaracaoAceitacao",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Denominacao",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diretor",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiretorCC",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DiretorCcDataValidade",
                schema: "weges",
                table: "Servicos",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "DiretorCedulaProfissional",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiretorOrdem",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataValidade",
                schema: "weges",
                table: "LicencasERS",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Ficheiro",
                schema: "weges",
                table: "LicencasERS",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Licenca",
                schema: "weges",
                table: "LicencasERS",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPrestador",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                defaultValue: "",
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

            migrationBuilder.AddColumn<string>(
                name: "AutorizacaoInfarmed",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoApa",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "weges",
                table: "Entidades",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ordem",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Especialidade",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CC",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CcDataValidade",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "CedulaDataValidade",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CedulaProfissional",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "DeclaracaoAceitacao",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SubDiretor",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubDiretorCC",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "SubDiretorCcDataValidade",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "SubDiretorCedulaDataValidade",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "SubDiretorCedulaProfissional",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubDiretorOrdem",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Certificado",
                schema: "weges",
                table: "CertificadosERS",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataValidade",
                schema: "weges",
                table: "CertificadosERS",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Ficheiro",
                schema: "weges",
                table: "CertificadosERS",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Acesso",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcessoTipo = table.Column<int>(type: "integer", nullable: false),
                    Utilizador = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    EntidadeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acesso_Entidades_EntidadeId",
                        column: x => x.EntidadeId,
                        principalSchema: "weges",
                        principalTable: "Entidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    EntidadeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Entidades_EntidadeId",
                        column: x => x.EntidadeId,
                        principalSchema: "weges",
                        principalTable: "Entidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_CertificadoId",
                schema: "weges",
                table: "Servicos",
                column: "CertificadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Acesso_EntidadeId",
                schema: "weges",
                table: "Acesso",
                column: "EntidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_EntidadeId",
                schema: "weges",
                table: "Mensagem",
                column: "EntidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_DirecoesClinicas_DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos",
                column: "DirecaoClinicaId",
                principalSchema: "weges",
                principalTable: "DirecoesClinicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_CertificadosERS_CertificadoId",
                schema: "weges",
                table: "Servicos",
                column: "CertificadoId",
                principalSchema: "weges",
                principalTable: "CertificadosERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_LicencasERS_LicencaId",
                schema: "weges",
                table: "Servicos",
                column: "LicencaId",
                principalSchema: "weges",
                principalTable: "LicencasERS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_DirecoesClinicas_DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_CertificadosERS_CertificadoId",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_LicencasERS_LicencaId",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropTable(
                name: "Acesso",
                schema: "weges");

            migrationBuilder.DropTable(
                name: "Mensagem",
                schema: "weges");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_CertificadoId",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "CertificadoId",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "DeclaracaoAceitacao",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Denominacao",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Diretor",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "DiretorCC",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "DiretorCcDataValidade",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "DiretorCedulaProfissional",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "DiretorOrdem",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Especialidade",
                schema: "weges",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "DataValidade",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "Ficheiro",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "Licenca",
                schema: "weges",
                table: "LicencasERS");

            migrationBuilder.DropColumn(
                name: "AutorizacaoInfarmed",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "CodigoApa",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "Horario",
                schema: "weges",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "weges",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "CC",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "CcDataValidade",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "CedulaDataValidade",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "CedulaProfissional",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "DeclaracaoAceitacao",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "SubDiretor",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "SubDiretorCC",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "SubDiretorCcDataValidade",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "SubDiretorCedulaDataValidade",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "SubDiretorCedulaProfissional",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "SubDiretorOrdem",
                schema: "weges",
                table: "DirecoesClinicas");

            migrationBuilder.DropColumn(
                name: "Certificado",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "DataValidade",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.DropColumn(
                name: "Ficheiro",
                schema: "weges",
                table: "CertificadosERS");

            migrationBuilder.RenameColumn(
                name: "LicencaId",
                schema: "weges",
                table: "Servicos",
                newName: "TipologiaId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicos_LicencaId",
                schema: "weges",
                table: "Servicos",
                newName: "IX_Servicos_TipologiaId");

            migrationBuilder.RenameColumn(
                name: "DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos",
                newName: "ParecerAnpcId");

            migrationBuilder.RenameColumn(
                name: "DataInicioAtividade",
                schema: "weges",
                table: "Estabelecimentos",
                newName: "InicioAtividade");

            migrationBuilder.RenameIndex(
                name: "IX_Estabelecimentos_DirecaoClinicaId",
                schema: "weges",
                table: "Estabelecimentos",
                newName: "IX_Estabelecimentos_ParecerAnpcId");

            migrationBuilder.AlterColumn<string>(
                name: "Horario",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "Servicos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                schema: "weges",
                table: "Servicos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "Servicos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsavel",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "LicencasERS",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "LicencasERS",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataSubmissao",
                schema: "weges",
                table: "LicencasERS",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FicheiroId",
                schema: "weges",
                table: "LicencasERS",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "LicencasERS",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "LicencasERS",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<string>(
                name: "NrLicenca",
                schema: "weges",
                table: "LicencasERS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                schema: "weges",
                table: "LicencasERS",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoPrestador",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Denominacao",
                schema: "weges",
                table: "Estabelecimentos",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "Estabelecimentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "Estabelecimentos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "Estabelecimentos",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "Entidades",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "Entidades",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<string>(
                name: "Denominacao",
                schema: "weges",
                table: "Entidades",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "weges",
                table: "Entidades",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailNotificacoesERS",
                schema: "weges",
                table: "Entidades",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailNotificacoesGerais",
                schema: "weges",
                table: "Entidades",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "Entidades",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "Entidades",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                schema: "weges",
                table: "Entidades",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NifNipc",
                schema: "weges",
                table: "Entidades",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NrERS",
                schema: "weges",
                table: "Entidades",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                schema: "weges",
                table: "Entidades",
                type: "character varying(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                schema: "weges",
                table: "Entidades",
                type: "character varying(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ordem",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Especialidade",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<long>(
                name: "EspecialidadeId",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EstabelecimentoId",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Identificacao",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidadeIdentificacao",
                schema: "weges",
                table: "DirecoesClinicas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "CertificadosERS",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "CertificadosERS",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExpiracao",
                schema: "weges",
                table: "CertificadosERS",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExpiracaoTaxa",
                schema: "weges",
                table: "CertificadosERS",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamentoTaxa",
                schema: "weges",
                table: "CertificadosERS",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSubmissao",
                schema: "weges",
                table: "CertificadosERS",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FicheiroId",
                schema: "weges",
                table: "CertificadosERS",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "CertificadosERS",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "CertificadosERS",
                type: "text",
                nullable: true,
                defaultValue: "system-usr");

            migrationBuilder.AddColumn<string>(
                name: "NrCertificado",
                schema: "weges",
                table: "CertificadosERS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                schema: "weges",
                table: "CertificadosERS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                schema: "weges",
                table: "CertificadosERS",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnexoTipos",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Tipo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexoTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodCaes",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Designacao = table.Column<string>(type: "text", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodCaes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorTipo",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Tipo = table.Column<string>(type: "text", nullable: false)
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
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NomeOriginal = table.Column<string>(type: "text", nullable: true),
                    Tipo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true)
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
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipologias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodCaeEntidade",
                schema: "weges",
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
                        principalSchema: "weges",
                        principalTable: "CodCaes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CodCaeEntidade_Entidades_EntidadesId",
                        column: x => x.EntidadesId,
                        principalSchema: "weges",
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ColaboradorTipoId = table.Column<long>(type: "bigint", nullable: false),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    ServicoId = table.Column<long>(type: "bigint", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Especialidade = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    InicioAtividade = table.Column<DateOnly>(type: "date", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    NrIdentificacao = table.Column<string>(type: "text", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: false),
                    TotalHoras = table.Column<int>(type: "integer", nullable: false)
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
                name: "Anexos",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AnexoTipoId = table.Column<long>(type: "bigint", nullable: false),
                    FicheiroId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Observacoes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Submetido = table.Column<DateOnly>(type: "date", nullable: false)
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
                name: "Formacao",
                schema: "weges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ColaboradorId = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    HorasFormacao = table.Column<int>(type: "integer", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, defaultValue: "system-usr"),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true)
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
                name: "IX_DirecoesClinicas_TipologiaId",
                schema: "weges",
                table: "DirecoesClinicas",
                column: "TipologiaId");

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
                name: "IX_CodCaeEntidade_EntidadesId",
                schema: "weges",
                table: "CodCaeEntidade",
                column: "EntidadesId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CertificadosERS_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "CertificadosERS",
                column: "EstabelecimentoId",
                principalSchema: "weges",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificadosERS_Ficheiros_FicheiroId",
                schema: "weges",
                table: "CertificadosERS",
                column: "FicheiroId",
                principalSchema: "weges",
                principalTable: "Ficheiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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

            migrationBuilder.AddForeignKey(
                name: "FK_LicencasERS_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "LicencasERS",
                column: "EstabelecimentoId",
                principalSchema: "weges",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
