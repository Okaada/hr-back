using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_system_v2.Migrations
{
    public partial class DBUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Functions_FunctionId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Genders_GenderType",
                table: "People");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_People_GenderType",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_FunctionId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "GenderType",
                table: "People");

            migrationBuilder.DropColumn(
                name: "FunctionId",
                table: "Contracts");

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "People",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ContractId",
                table: "People",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Contracts_ContractId",
                table: "People",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Contracts_ContractId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ContractId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "GenderType",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FunctionId",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Functions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderType);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_GenderType",
                table: "People",
                column: "GenderType");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FunctionId",
                table: "Contracts",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Functions_DepartmentId",
                table: "Functions",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Functions_FunctionId",
                table: "Contracts",
                column: "FunctionId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Genders_GenderType",
                table: "People",
                column: "GenderType",
                principalTable: "Genders",
                principalColumn: "GenderType",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
