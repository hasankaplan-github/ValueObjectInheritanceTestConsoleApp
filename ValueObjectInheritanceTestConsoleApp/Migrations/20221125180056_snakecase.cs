using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValueObjectInheritanceTestConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class snakecase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "customer",
                newName: "document_type");

            migrationBuilder.RenameColumn(
                name: "DocumentSerialNumber",
                table: "customer",
                newName: "document_serial_number");

            migrationBuilder.RenameColumn(
                name: "DocumentIssueDate",
                table: "customer",
                newName: "document_issue_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "document_type",
                table: "customer",
                newName: "DocumentType");

            migrationBuilder.RenameColumn(
                name: "document_serial_number",
                table: "customer",
                newName: "DocumentSerialNumber");

            migrationBuilder.RenameColumn(
                name: "document_issue_date",
                table: "customer",
                newName: "DocumentIssueDate");
        }
    }
}
