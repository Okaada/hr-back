using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hr_system_v2.Migrations
{
    public partial class BenefitsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefitsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractBenefits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BenefitTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractBenefits_BenefitsType_BenefitTypeId",
                        column: x => x.BenefitTypeId,
                        principalTable: "BenefitsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractBenefits_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractBenefits_BenefitTypeId",
                table: "ContractBenefits",
                column: "BenefitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBenefits_ContractId",
                table: "ContractBenefits",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractBenefits");

            migrationBuilder.DropTable(
                name: "BenefitsType");
        }
    }
}
