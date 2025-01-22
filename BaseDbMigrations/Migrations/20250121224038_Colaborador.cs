using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDbMigrations.Migrations
{
    /// <inheritdoc />
    public partial class Colaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_ColaboradorTipo_ColaboradorTipoId",
                schema: "weges",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Servicos_ServicoId",
                schema: "weges",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Formacao_Colaborador_ColaboradorId",
                schema: "weges",
                table: "Formacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colaborador",
                schema: "weges",
                table: "Colaborador");

            migrationBuilder.RenameTable(
                name: "Colaborador",
                schema: "weges",
                newName: "Colaboradores",
                newSchema: "weges");

            migrationBuilder.RenameIndex(
                name: "IX_Colaborador_ServicoId",
                schema: "weges",
                table: "Colaboradores",
                newName: "IX_Colaboradores_ServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Colaborador_EstabelecimentoId",
                schema: "weges",
                table: "Colaboradores",
                newName: "IX_Colaboradores_EstabelecimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Colaborador_ColaboradorTipoId",
                schema: "weges",
                table: "Colaboradores",
                newName: "IX_Colaboradores_ColaboradorTipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colaboradores",
                schema: "weges",
                table: "Colaboradores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_ColaboradorTipo_ColaboradorTipoId",
                schema: "weges",
                table: "Colaboradores",
                column: "ColaboradorTipoId",
                principalSchema: "weges",
                principalTable: "ColaboradorTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "Colaboradores",
                column: "EstabelecimentoId",
                principalSchema: "weges",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Servicos_ServicoId",
                schema: "weges",
                table: "Colaboradores",
                column: "ServicoId",
                principalSchema: "weges",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Formacao_Colaboradores_ColaboradorId",
                schema: "weges",
                table: "Formacao",
                column: "ColaboradorId",
                principalSchema: "weges",
                principalTable: "Colaboradores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_ColaboradorTipo_ColaboradorTipoId",
                schema: "weges",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Servicos_ServicoId",
                schema: "weges",
                table: "Colaboradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Formacao_Colaboradores_ColaboradorId",
                schema: "weges",
                table: "Formacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colaboradores",
                schema: "weges",
                table: "Colaboradores");

            migrationBuilder.RenameTable(
                name: "Colaboradores",
                schema: "weges",
                newName: "Colaborador",
                newSchema: "weges");

            migrationBuilder.RenameIndex(
                name: "IX_Colaboradores_ServicoId",
                schema: "weges",
                table: "Colaborador",
                newName: "IX_Colaborador_ServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Colaboradores_EstabelecimentoId",
                schema: "weges",
                table: "Colaborador",
                newName: "IX_Colaborador_EstabelecimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Colaboradores_ColaboradorTipoId",
                schema: "weges",
                table: "Colaborador",
                newName: "IX_Colaborador_ColaboradorTipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colaborador",
                schema: "weges",
                table: "Colaborador",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_ColaboradorTipo_ColaboradorTipoId",
                schema: "weges",
                table: "Colaborador",
                column: "ColaboradorTipoId",
                principalSchema: "weges",
                principalTable: "ColaboradorTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Estabelecimentos_EstabelecimentoId",
                schema: "weges",
                table: "Colaborador",
                column: "EstabelecimentoId",
                principalSchema: "weges",
                principalTable: "Estabelecimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Servicos_ServicoId",
                schema: "weges",
                table: "Colaborador",
                column: "ServicoId",
                principalSchema: "weges",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Formacao_Colaborador_ColaboradorId",
                schema: "weges",
                table: "Formacao",
                column: "ColaboradorId",
                principalSchema: "weges",
                principalTable: "Colaborador",
                principalColumn: "Id");
        }
    }
}
