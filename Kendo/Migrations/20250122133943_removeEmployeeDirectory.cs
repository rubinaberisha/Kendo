using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kendo.Migrations
{
    public partial class removeEmployeeDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDirectories_EmployeeDirectories_ReportsTo",
                table: "EmployeeDirectories");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDirectories_ReportsTo",
                table: "EmployeeDirectories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDirectories_ReportsTo",
                table: "EmployeeDirectories",
                column: "ReportsTo");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDirectories_EmployeeDirectories_ReportsTo",
                table: "EmployeeDirectories",
                column: "ReportsTo",
                principalTable: "EmployeeDirectories",
                principalColumn: "EmployeeId");
        }
    }
}
