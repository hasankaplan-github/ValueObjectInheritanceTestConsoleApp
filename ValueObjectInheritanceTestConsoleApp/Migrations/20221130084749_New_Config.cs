using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValueObjectInheritanceTestConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class NewConfig : Migration
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
                    documentissuedate = table.Column<DateTime>(name: "document_issue_date", type: "timestamp with time zone", nullable: true),
                    documentserialnumber = table.Column<string>(name: "document_serial_number", type: "text", nullable: true),
                    documenttype = table.Column<int>(name: "document_type", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "special_customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_special_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "special_customer__document_containers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    specialcustomerid = table.Column<Guid>(name: "special_customer_id", type: "uuid", nullable: false),
                    documentissuedate = table.Column<DateTime>(name: "document_issue_date", type: "timestamp with time zone", nullable: true),
                    documentserialnumber = table.Column<string>(name: "document_serial_number", type: "text", nullable: true),
                    documenttype = table.Column<int>(name: "document_type", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_special_customer__document_containers", x => x.id);
                    table.ForeignKey(
                        name: "fk_special_customer__document_containers_special_customer_spec",
                        column: x => x.specialcustomerid,
                        principalTable: "special_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_special_customer__document_containers_special_customer_id",
                table: "special_customer__document_containers",
                column: "special_customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "special_customer__document_containers");

            migrationBuilder.DropTable(
                name: "special_customer");
        }
    }
}
