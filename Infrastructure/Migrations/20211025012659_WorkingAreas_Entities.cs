using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class WorkingAreas_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("303efe87-b6f6-42c4-8d74-c56de233b9c0"));

            migrationBuilder.CreateTable(
                name: "WorkingArea",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingAreaAssignation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkingAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingAreaAssignation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingAreaAssignation_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkingAreaAssignation_WorkingArea_WorkingAreaId",
                        column: x => x.WorkingAreaId,
                        principalTable: "WorkingArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("3ea3ac53-6166-47b5-9ccb-32f98695f9ec"), null, null, null, "Company", null, true, "Test Company", null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingAreaAssignation_ApplicationUserId",
                table: "WorkingAreaAssignation",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingAreaAssignation_WorkingAreaId",
                table: "WorkingAreaAssignation",
                column: "WorkingAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingAreaAssignation");

            migrationBuilder.DropTable(
                name: "WorkingArea");

            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("3ea3ac53-6166-47b5-9ccb-32f98695f9ec"));

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("303efe87-b6f6-42c4-8d74-c56de233b9c0"), null, null, null, "Company", null, true, "Test Company", null, null, null });
        }
    }
}
