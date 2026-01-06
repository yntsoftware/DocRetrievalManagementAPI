using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocRetrievalManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 450, nullable: true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    TableName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OldValues = table.Column<string>(type: "TEXT", nullable: true),
                    NewValues = table.Column<string>(type: "TEXT", nullable: true),
                    AffectedColumns = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryKey = table.Column<string>(type: "TEXT", nullable: true),
                    ControllerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ActionName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IPAddress = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    PageAccessed = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SessionId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    UrlReferrer = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UploadedBy = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
