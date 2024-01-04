using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FlexDietAiDAL.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BashPassword = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UsersData",
                columns: table => new
                {
                    UserDataId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Dof = table.Column<DateOnly>(type: "date", nullable: false),
                    Somatotype = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersData", x => x.UserDataId);
                    table.ForeignKey(
                        name: "FK_UsersData_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersDiets",
                columns: table => new
                {
                    UserDietId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Goal = table.Column<string>(type: "text", nullable: false),
                    InitialDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDiets", x => x.UserDietId);
                    table.ForeignKey(
                        name: "FK_UsersDiets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersHealth",
                columns: table => new
                {
                    UsersHealthId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersHealth", x => x.UsersHealthId);
                    table.ForeignKey(
                        name: "FK_UsersHealth_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietsMenus",
                columns: table => new
                {
                    DietMenuId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Menu = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Kcal = table.Column<int>(type: "integer", nullable: false),
                    InitialDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserDietId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietsMenus", x => x.DietMenuId);
                    table.ForeignKey(
                        name: "FK_DietsMenus_UsersDiets_UserDietId",
                        column: x => x.UserDietId,
                        principalTable: "UsersDiets",
                        principalColumn: "UserDietId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietsMenus_UserDietId",
                table: "DietsMenus",
                column: "UserDietId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersData_UserId",
                table: "UsersData",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersDiets_UserId",
                table: "UsersDiets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersHealth_UserId",
                table: "UsersHealth",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietsMenus");

            migrationBuilder.DropTable(
                name: "UsersData");

            migrationBuilder.DropTable(
                name: "UsersHealth");

            migrationBuilder.DropTable(
                name: "UsersDiets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
