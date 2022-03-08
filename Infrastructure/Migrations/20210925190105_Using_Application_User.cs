using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Using_Application_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("64b87ca0-7920-4fcf-b5c1-df681128b8e1"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizacionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "Discriminator", "Enabled", "Name" },
                values: new object[] { new Guid("cf91cd74-52e6-4d2c-9848-d7d8c5ad2cab"), "Company", true, "Test Company" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizacionId",
                table: "AspNetUsers",
                column: "OrganizacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Organizacions_OrganizacionId",
                table: "AspNetUsers",
                column: "OrganizacionId",
                principalTable: "Organizacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Organizacions_OrganizacionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OrganizacionId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("cf91cd74-52e6-4d2c-9848-d7d8c5ad2cab"));

            migrationBuilder.DropColumn(
                name: "OrganizacionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "Discriminator", "Enabled", "Name" },
                values: new object[] { new Guid("64b87ca0-7920-4fcf-b5c1-df681128b8e1"), "Company", true, "Test Company" });
        }
    }
}
