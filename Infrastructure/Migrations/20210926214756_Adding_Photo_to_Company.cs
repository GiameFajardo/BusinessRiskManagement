using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Adding_Photo_to_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("e5d72f06-663e-4fe9-80a2-44bd0c995720"));

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo" },
                values: new object[] { new Guid("7a1fe283-9182-43b1-b4f6-8bc647ddfc39"), null, null, "Company", null, true, "Test Company", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("7a1fe283-9182-43b1-b4f6-8bc647ddfc39"));

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Organizacions");

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "Discriminator", "EMail", "Enabled", "Name", "Phone" },
                values: new object[] { new Guid("e5d72f06-663e-4fe9-80a2-44bd0c995720"), null, null, "Company", null, true, "Test Company", null });
        }
    }
}
