using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleLearningSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AmountLimit = table.Column<int>(type: "int", nullable: true),
                    CourseWeek = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CourseTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__C92D71A72310B94D", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Material__C50610F7CA45FD2A", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__32C52B99986BB5C6", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Has",
                columns: table => new
                {
                    HasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Has__C8ABBCAD3C393339", x => x.HasId);
                    table.ForeignKey(
                        name: "FK_CourseMaterial",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_Material",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId");
                });

            migrationBuilder.CreateTable(
                name: "Enroll",
                columns: table => new
                {
                    EnrollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enroll__405B562C4C58DEEE", x => x.EnrollId);
                    table.ForeignKey(
                        name: "FK_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enroll_CourseId",
                table: "Enroll",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enroll_StudentId",
                table: "Enroll",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Has_CourseId",
                table: "Has",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Has_MaterialId",
                table: "Has",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enroll");

            migrationBuilder.DropTable(
                name: "Has");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
