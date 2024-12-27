using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weges_v2.DbMigrations.Migrations.UtilizadoresDb
{
    /// <inheritdoc />
    public partial class RenameSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "weges_users");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "users",
                newName: "AspNetUserTokens",
                newSchema: "weges_users");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "users",
                newName: "AspNetUsers",
                newSchema: "weges_users");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "users",
                newName: "AspNetUserRoles",
                newSchema: "weges_users");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "users",
                newName: "AspNetUserLogins",
                newSchema: "weges_users");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "users",
                newName: "AspNetUserClaims",
                newSchema: "weges_users");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "users",
                newName: "AspNetRoles",
                newSchema: "weges_users");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "users",
                newName: "AspNetRoleClaims",
                newSchema: "weges_users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "weges_users",
                newName: "AspNetUserTokens",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "weges_users",
                newName: "AspNetUsers",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "weges_users",
                newName: "AspNetUserRoles",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "weges_users",
                newName: "AspNetUserLogins",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "weges_users",
                newName: "AspNetUserClaims",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "weges_users",
                newName: "AspNetRoles",
                newSchema: "users");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "weges_users",
                newName: "AspNetRoleClaims",
                newSchema: "users");
        }
    }
}
