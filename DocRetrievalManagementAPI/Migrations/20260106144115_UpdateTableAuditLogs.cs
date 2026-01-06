using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocRetrievalManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableAuditLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "AffectedColumns",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "NewValues",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "OldValues",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "PageAccessed",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "PrimaryKey",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "UrlReferrer",
                table: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AuditLogs",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "AuditLogs",
                newName: "Timestamp");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "AuditLogs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "AuditLogs",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "AuditLogs",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "AuditLogs",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffectedColumns",
                table: "AuditLogs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "AuditLogs",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "AuditLogs",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewValues",
                table: "AuditLogs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OldValues",
                table: "AuditLogs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageAccessed",
                table: "AuditLogs",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryKey",
                table: "AuditLogs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "AuditLogs",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlReferrer",
                table: "AuditLogs",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
