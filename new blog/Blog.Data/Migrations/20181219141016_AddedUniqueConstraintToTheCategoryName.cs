using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddedUniqueConstraintToTheCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2fcf0f2b-9fe6-4848-bd59-dfb70f64b628", "22fb7fd4-f3d7-4619-a622-d9e786e80e0d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6aa2979e-ac5a-41c0-91f4-e172edd4d0c2", "da147bb8-247c-4199-8f0c-30432b5b04a9" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "462df476-fb4c-468a-81e6-209b3a29a426", "accf9581-4a5d-4979-9dcd-07e5089960bd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c19edc7-e3ee-4aa3-b730-0b2c8668c239", "493c1fbb-df5f-43fe-8989-afaa431718b6", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0c19edc7-e3ee-4aa3-b730-0b2c8668c239", "493c1fbb-df5f-43fe-8989-afaa431718b6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "462df476-fb4c-468a-81e6-209b3a29a426", "accf9581-4a5d-4979-9dcd-07e5089960bd" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6aa2979e-ac5a-41c0-91f4-e172edd4d0c2", "da147bb8-247c-4199-8f0c-30432b5b04a9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2fcf0f2b-9fe6-4848-bd59-dfb70f64b628", "22fb7fd4-f3d7-4619-a622-d9e786e80e0d", "User", "USER" });
        }
    }
}
