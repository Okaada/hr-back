using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_system_v2.Migrations
{
    public partial class FixDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Dependents_EmployeeId",
                table: "Dependents",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_Employees_EmployeeId",
                table: "Dependents",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_Employees_EmployeeId",
                table: "Dependents");

            migrationBuilder.DropIndex(
                name: "IX_Dependents_EmployeeId",
                table: "Dependents");
        }
    }
}
