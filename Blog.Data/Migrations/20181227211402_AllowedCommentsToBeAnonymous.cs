using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AllowedCommentsToBeAnonymous : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ae1836f2-b08c-4bf8-87c7-04cf0bcd9424", "de19443c-a8e5-4236-a07f-50fc5480f9d5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bb3c42fa-b0c6-4b1f-b8d1-175eb77987a5", "93cfb75f-6930-4cbf-9081-b8132e789050" });

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AuthorUsername",
                table: "Comments",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07ac5ba2-0c1c-4515-ac65-aeb758cabd51", "753f9667-28fc-46b2-af0a-31ebcc15f985", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e3fbc20-c205-4055-9625-bdeb140b4bca", "06ec1662-b5b4-4c12-913d-e173c7c1e755", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.Sql($"ALTER TABLE Comments ADD CONSTRAINT CHK_IsAuthorAnonymous " +
            //                     $"CHECK (AuthorId IS NOT NULL OR AuthorUsername IS NOT NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "07ac5ba2-0c1c-4515-ac65-aeb758cabd51", "753f9667-28fc-46b2-af0a-31ebcc15f985" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5e3fbc20-c205-4055-9625-bdeb140b4bca", "06ec1662-b5b4-4c12-913d-e173c7c1e755" });

            migrationBuilder.DropColumn(
                name: "AuthorUsername",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb3c42fa-b0c6-4b1f-b8d1-175eb77987a5", "93cfb75f-6930-4cbf-9081-b8132e789050", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae1836f2-b08c-4bf8-87c7-04cf0bcd9424", "de19443c-a8e5-4236-a07f-50fc5480f9d5", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
