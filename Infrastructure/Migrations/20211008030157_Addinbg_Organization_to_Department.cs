using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Addinbg_Organization_to_Department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("f6b6169d-3a85-4b0c-9af4-26042785610f"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizacionId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("dae74823-7d56-4f91-8a62-14fd064fbeab"), null, null, null, "Company", null, true, "Test Company", null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrganizacionId",
                table: "Departments",
                column: "OrganizacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Organizacions_OrganizacionId",
                table: "Departments",
                column: "OrganizacionId",
                principalTable: "Organizacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Organizacions_OrganizacionId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_OrganizacionId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("dae74823-7d56-4f91-8a62-14fd064fbeab"));

            migrationBuilder.DropColumn(
                name: "OrganizacionId",
                table: "Departments");

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("f6b6169d-3a85-4b0c-9af4-26042785610f"), null, null, null, "Company", null, true, "Test Company", null, null, null });
        }
    }
}
