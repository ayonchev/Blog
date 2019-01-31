using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class ChangedTheNameOfTheAnonymousAuthorCredentialsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "07ac5ba2-0c1c-4515-ac65-aeb758cabd51", "753f9667-28fc-46b2-af0a-31ebcc15f985" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5e3fbc20-c205-4055-9625-bdeb140b4bca", "06ec1662-b5b4-4c12-913d-e173c7c1e755" });

            migrationBuilder.RenameColumn(
                name: "AuthorUsername",
                table: "Comments",
                newName: "AnonAuthorEmail");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50a65107-4126-4112-9fdf-efcc0818be2d", "dd320a89-efd4-4741-ae9b-b84de027ac53", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c384af8f-1830-45e8-99ac-6c9adac3fa78", "da731388-1671-4ce6-8344-4010be920943", "User", "USER" });

            //migrationBuilder.Sql($"ALTER TABLE Comments ADD CONSTRAINT CHK_IsAuthorAnonymous " +
            //                     $"CHECK (AuthorId IS NOT NULL OR AnonAuthorEmail IS NOT NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "50a65107-4126-4112-9fdf-efcc0818be2d", "dd320a89-efd4-4741-ae9b-b84de027ac53" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c384af8f-1830-45e8-99ac-6c9adac3fa78", "da731388-1671-4ce6-8344-4010be920943" });

            migrationBuilder.RenameColumn(
                name: "AnonAuthorEmail",
                table: "Comments",
                newName: "AuthorUsername");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07ac5ba2-0c1c-4515-ac65-aeb758cabd51", "753f9667-28fc-46b2-af0a-31ebcc15f985", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e3fbc20-c205-4055-9625-bdeb140b4bca", "06ec1662-b5b4-4c12-913d-e173c7c1e755", "User", "USER" });
        }
    }
}
