using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexDietAiDAL.Migrations
{
    /// <inheritdoc />
    public partial class OneUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("76864f43-6d6f-4d96-a960-fd8d285a559a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BashPassword", "CreationDate", "Email", "UserDataId" },
                values: new object[] { new Guid("843034a8-ffca-443e-a7bf-75d126e5ddb4"), "nmjkdwmd1023012", new DateTime(2024, 1, 3, 12, 20, 31, 185, DateTimeKind.Utc).AddTicks(885), "teste@gmailcom", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("843034a8-ffca-443e-a7bf-75d126e5ddb4"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BashPassword", "CreationDate", "Email", "UserDataId" },
                values: new object[] { new Guid("76864f43-6d6f-4d96-a960-fd8d285a559a"), "nmjkdwmd1023012", new DateTime(2024, 1, 3, 9, 19, 10, 788, DateTimeKind.Local).AddTicks(3119), "teste@gmailcom", 0 });
        }
    }
}
