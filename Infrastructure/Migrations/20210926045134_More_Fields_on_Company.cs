using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class More_Fields_on_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("cf91cd74-52e6-4d2c-9848-d7d8c5ad2cab"));

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "Discriminator", "EMail", "Enabled", "Name", "Phone" },
                values: new object[] { new Guid("e5d72f06-663e-4fe9-80a2-44bd0c995720"), null, null, "Company", null, true, "Test Company", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("e5d72f06-663e-4fe9-80a2-44bd0c995720"));

            migrationBuilder.DropColumn(
                name: "About",
                table: "Organizacions");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Organizacions");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Organizacions");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Organizacions");

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "Discriminator", "Enabled", "Name" },
                values: new object[] { new Guid("cf91cd74-52e6-4d2c-9848-d7d8c5ad2cab"), "Company", true, "Test Company" });
        }
    }
}
