using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Adding_Fields_to_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("7a1fe283-9182-43b1-b4f6-8bc647ddfc39"));

            migrationBuilder.AddColumn<string>(
                name: "CompanyEnvironmentDescription",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityAndHealthObjeptives",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("9c047681-d251-4963-a8b1-b3b815104ac9"), null, null, null, "Company", null, true, "Test Company", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("9c047681-d251-4963-a8b1-b3b815104ac9"));

            migrationBuilder.DropColumn(
                name: "CompanyEnvironmentDescription",
                table: "Organizacions");

            migrationBuilder.DropColumn(
                name: "SecurityAndHealthObjeptives",
                table: "Organizacions");

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo" },
                values: new object[] { new Guid("7a1fe283-9182-43b1-b4f6-8bc647ddfc39"), null, null, "Company", null, true, "Test Company", null, null });
        }
    }
}
