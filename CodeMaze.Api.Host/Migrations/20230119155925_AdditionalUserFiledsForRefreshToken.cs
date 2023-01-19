using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeMaze.Api.Host.Migrations
{
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfc58bec-9a72-408e-858e-3997f66af19f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e035d48e-9d14-456b-af62-da2138220f6e");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33d7bc23-d122-4b2f-8b84-2eb24eb5319b", "73895ff8-e22f-40d5-96a4-f84cb06aff52", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46b7d104-26a9-45d1-aa0a-16649f7d4ee0", "986b4e54-f348-4ea8-a980-fc8f6abb832c", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33d7bc23-d122-4b2f-8b84-2eb24eb5319b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46b7d104-26a9-45d1-aa0a-16649f7d4ee0");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfc58bec-9a72-408e-858e-3997f66af19f", "3c9c46ea-6400-4b0b-8b8f-39af2830e96a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e035d48e-9d14-456b-af62-da2138220f6e", "7affa4f2-0c4e-4aaf-b23d-0402d920761d", "Manager", "MANAGER" });
        }
    }
}
