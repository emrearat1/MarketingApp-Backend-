using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Roles_Addition2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce84a026-87f6-47bb-9337-32faa4e599eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f37957d7-8fce-4e0e-b28f-9d690806dfd2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23c43434-d618-487c-b0db-24c6b7dc307f", "243e1a5c-b10e-4270-aac5-dc0384678684", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f64ab032-6c85-4c5a-9928-9ac89eb9610f", "43e31a77-9d1e-47c0-8c8c-3a8cd195b16f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23c43434-d618-487c-b0db-24c6b7dc307f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f64ab032-6c85-4c5a-9928-9ac89eb9610f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce84a026-87f6-47bb-9337-32faa4e599eb", "7bb9d4be-97ee-4ce8-a847-d72cecdd23bd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f37957d7-8fce-4e0e-b28f-9d690806dfd2", "58f2f3a3-12dd-4a7c-8c06-036ce76f8b1b", "User", "USER" });
        }
    }
}
