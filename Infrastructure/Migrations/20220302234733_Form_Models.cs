using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Form_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("3ea3ac53-6166-47b5-9ccb-32f98695f9ec"));

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryMetas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryMetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryMetas_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("4d2ed2c7-ab38-4839-a35c-3702188b39e6"), null, null, null, "Company", null, true, "Test Company", null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_FormId",
                table: "Entries",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryMetas_EntryId",
                table: "EntryMetas",
                column: "EntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryMetas");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("4d2ed2c7-ab38-4839-a35c-3702188b39e6"));

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("3ea3ac53-6166-47b5-9ccb-32f98695f9ec"), null, null, null, "Company", null, true, "Test Company", null, null, null });
        }
    }
}
