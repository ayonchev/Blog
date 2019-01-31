using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddedMaxlengthToTheCommentContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0c19edc7-e3ee-4aa3-b730-0b2c8668c239", "493c1fbb-df5f-43fe-8989-afaa431718b6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "462df476-fb4c-468a-81e6-209b3a29a426", "accf9581-4a5d-4979-9dcd-07e5089960bd" });

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb3c42fa-b0c6-4b1f-b8d1-175eb77987a5", "93cfb75f-6930-4cbf-9081-b8132e789050", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae1836f2-b08c-4bf8-87c7-04cf0bcd9424", "de19443c-a8e5-4236-a07f-50fc5480f9d5", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ae1836f2-b08c-4bf8-87c7-04cf0bcd9424", "de19443c-a8e5-4236-a07f-50fc5480f9d5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bb3c42fa-b0c6-4b1f-b8d1-175eb77987a5", "93cfb75f-6930-4cbf-9081-b8132e789050" });

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 400);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "462df476-fb4c-468a-81e6-209b3a29a426", "accf9581-4a5d-4979-9dcd-07e5089960bd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c19edc7-e3ee-4aa3-b730-0b2c8668c239", "493c1fbb-df5f-43fe-8989-afaa431718b6", "User", "USER" });
        }
    }
}
