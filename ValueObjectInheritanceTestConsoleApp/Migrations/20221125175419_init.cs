using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValueObjectInheritanceTestConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    DocumentIssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DocumentSerialNumber = table.Column<string>(type: "text", nullable: true),
                    DocumentType = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
