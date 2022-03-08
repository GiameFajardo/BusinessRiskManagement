using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Adding_Department_to_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("dae74823-7d56-4f91-8a62-14fd064fbeab"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("303efe87-b6f6-42c4-8d74-c56de233b9c0"), null, null, null, "Company", null, true, "Test Company", null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Organizacions",
                keyColumn: "Id",
                keyValue: new Guid("303efe87-b6f6-42c4-8d74-c56de233b9c0"));

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Organizacions",
                columns: new[] { "Id", "About", "Address", "CompanyEnvironmentDescription", "Discriminator", "EMail", "Enabled", "Name", "Phone", "Photo", "SecurityAndHealthObjeptives" },
                values: new object[] { new Guid("dae74823-7d56-4f91-8a62-14fd064fbeab"), null, null, null, "Company", null, true, "Test Company", null, null, null });
        }
    }
}
