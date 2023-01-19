using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeMaze.Api.Host.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfc58bec-9a72-408e-858e-3997f66af19f", "3c9c46ea-6400-4b0b-8b8f-39af2830e96a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e035d48e-9d14-456b-af62-da2138220f6e", "7affa4f2-0c4e-4aaf-b23d-0402d920761d", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfc58bec-9a72-408e-858e-3997f66af19f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e035d48e-9d14-456b-af62-da2138220f6e");
        }
    }
}
