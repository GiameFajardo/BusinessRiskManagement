using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Adding_Fields_to_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("9c047681-d251-4963-a8b1-b3b815104ac9"));

            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("d35d3c7e-2520-42c9-8208-b7ebbbc5715a"), null, null, null, "Company", null, true, "Test Company", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("d35d3c7e-2520-42c9-8208-b7ebbbc5715a"));

            migrationBuilder.DropColumn(
                name: "Identification",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("9c047681-d251-4963-a8b1-b3b815104ac9"), null, null, null, "Company", null, true, "Test Company", null, null, null });
        }
    }
}
