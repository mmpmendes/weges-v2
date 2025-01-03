using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class MassiveChanges : Migration
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

            migrationBuilder.DeleteData(
                schema: "weges",
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "weges",
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true,
                defaultValue: "system-usr",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "Servicos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true,
                defaultValue: "system-usr",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "Servicos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "system-usr");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "weges",
                table: "Servicos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "weges",
                table: "Servicos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "system-usr");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "weges",
                table: "Servicos",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

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

            migrationBuilder.InsertData(
                schema: "weges",
                table: "Servicos",
                columns: new[] { "Id", "Created", "CreatedBy", "DataInicio", "EstabelecimentoId", "Horario", "Modified", "ModifiedBy", "Nome", "Observacoes", "Responsavel", "Tipologia", "TipologiaId" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateOnly(2023, 2, 20), 1L, "Horario 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Servico 1", "Observacoes 1", "Responsavel 1", "Tipologia 1", 1L },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateOnly(2023, 2, 20), 2L, "Horario 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Servico 2", "Observacoes 2", "Responsavel 2", "Tipologia 2", 2L }
                });
        }
    }
}
