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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    tasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    { new Guid("6badfd7c-e3ac-40e0-9db9-49e64b4fdcff"), "Create a project", new DateTime(2021, 7, 16, 15, 3, 42, 127, DateTimeKind.Local).AddTicks(1678), 5.12f, new DateTime(2021, 7, 15, 15, 3, 42, 127, DateTimeKind.Local).AddTicks(381), 0, "Creating a new Project" },
                    { new Guid("b7fea0d2-44c2-4961-9061-a77b8d60cef8"), "Adding Classes to Project", new DateTime(2021, 7, 18, 15, 3, 42, 127, DateTimeKind.Local).AddTicks(3167), 3.2f, new DateTime(2021, 7, 15, 15, 3, 42, 127, DateTimeKind.Local).AddTicks(3131), 0, "Class Modeling" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "Password", "UserName", "role" },
                values: new object[,]
                {
                    { new Guid("f574d1a5-c726-4697-be9a-6af7311ffbf1"), new DateTime(2021, 7, 15, 15, 3, 42, 125, DateTimeKind.Local).AddTicks(6832), "malek.ajmi@se.linedata.com", "malek123", "ajmimalek", 0 },
                    { new Guid("4728f314-eb27-4fe5-bc19-03a1dd7a07f0"), new DateTime(2021, 7, 15, 15, 3, 42, 125, DateTimeKind.Local).AddTicks(7659), "adel.adel@se.linedata.com", "adel336", "adeladel", 1 }
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
