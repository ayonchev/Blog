using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class SeededSomeRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1301c05-f162-4106-a787-32779f613d92", "bad9b798-d095-4834-a936-a1bba7329466", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92b1984c-15f5-452f-876f-6a50d6713b2c", "32e1d6eb-b25a-4c80-b92e-6c5f30954805", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "92b1984c-15f5-452f-876f-6a50d6713b2c", "32e1d6eb-b25a-4c80-b92e-6c5f30954805" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d1301c05-f162-4106-a787-32779f613d92", "bad9b798-d095-4834-a936-a1bba7329466" });
        }
    }
}
