using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserTasksManager.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estimate = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskUser",
                columns: table => new
                {
                    tasksId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUser", x => new { x.tasksId, x.usersId });
                    table.ForeignKey(
                        name: "FK_TaskUser_Tasks_tasksId",
                        column: x => x.tasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUser_Users_usersId",
                        column: x => x.usersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "EndDate", "Estimate", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "Create a project", new DateTime(2021, 7, 15, 12, 7, 37, 245, DateTimeKind.Local).AddTicks(1252), 5.12f, new DateTime(2021, 7, 14, 12, 7, 37, 245, DateTimeKind.Local).AddTicks(152), 0, "Creating a new Project" },
                    { 2, "Adding Classes to Project", new DateTime(2021, 7, 17, 12, 7, 37, 245, DateTimeKind.Local).AddTicks(2546), 3.2f, new DateTime(2021, 7, 14, 12, 7, 37, 245, DateTimeKind.Local).AddTicks(2521), 0, "Class Modeling" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "Password", "UserName", "role" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 14, 12, 7, 37, 243, DateTimeKind.Local).AddTicks(7192), "malek.ajmi@se.linedata.com", "malek123", "ajmimalek", 0 },
                    { 2, new DateTime(2021, 7, 14, 12, 7, 37, 243, DateTimeKind.Local).AddTicks(7880), "adel.adel@se.linedata.com", "adel336", "adeladel", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_usersId",
                table: "TaskUser",
                column: "usersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskUser");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
