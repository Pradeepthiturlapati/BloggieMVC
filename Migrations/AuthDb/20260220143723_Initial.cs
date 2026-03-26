using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41efc110-e697-4d35-b1d5-b45204fd2456", "41efc110-e697-4d35-b1d5-b45204fd2456", "SuperAdmin", "SuperAdmin" },
                    { "d2c8591b-98f6-4959-9f72-398c862ba397", "d2c8591b-98f6-4959-9f72-398c862ba397", "User", "User" },
                    { "ffb36028-9f0e-47bf-96a0-952c8ff0ea93", "ffb36028-9f0e-47bf-96a0-952c8ff0ea93", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41efc110-e697-4d35-b1d5-b45204fd2456");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2c8591b-98f6-4959-9f72-398c862ba397");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffb36028-9f0e-47bf-96a0-952c8ff0ea93");
        }
    }
}
