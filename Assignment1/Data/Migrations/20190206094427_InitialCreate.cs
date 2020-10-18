using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment1.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseAsignmentss",
                columns: table => new
                {
                    Assignment_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAsignmentss", x => x.Assignment_Name);
                });

            migrationBuilder.CreateTable(
                name: "Usercourses",
                columns: table => new
                {
                    Full_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usercourses", x => x.Full_Name);
                });

            migrationBuilder.CreateTable(
                name: "Asignmentss",
                columns: table => new
                {
                    Assignmentid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Assignmenttopic = table.Column<string>(nullable: true),
                    Submmittedto = table.Column<string>(nullable: true),
                    CourseAssignmentsAssignment_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignmentss", x => x.Assignmentid);
                    table.ForeignKey(
                        name: "FK_Asignmentss_CourseAsignmentss_CourseAssignmentsAssignment_Name",
                        column: x => x.CourseAssignmentsAssignment_Name,
                        principalTable: "CourseAsignmentss",
                        principalColumn: "Assignment_Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coursess",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    Semester = table.Column<string>(nullable: true),
                    CourseAssignmentsAssignment_Name = table.Column<string>(nullable: true),
                    UserCoursesFull_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coursess", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Coursess_CourseAsignmentss_CourseAssignmentsAssignment_Name",
                        column: x => x.CourseAssignmentsAssignment_Name,
                        principalTable: "CourseAsignmentss",
                        principalColumn: "Assignment_Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coursess_Usercourses_UserCoursesFull_Name",
                        column: x => x.UserCoursesFull_Name,
                        principalTable: "Usercourses",
                        principalColumn: "Full_Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignmentss_CourseAssignmentsAssignment_Name",
                table: "Asignmentss",
                column: "CourseAssignmentsAssignment_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Coursess_CourseAssignmentsAssignment_Name",
                table: "Coursess",
                column: "CourseAssignmentsAssignment_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Coursess_UserCoursesFull_Name",
                table: "Coursess",
                column: "UserCoursesFull_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignmentss");

            migrationBuilder.DropTable(
                name: "AuthUsers");

            migrationBuilder.DropTable(
                name: "Coursess");

            migrationBuilder.DropTable(
                name: "CourseAsignmentss");

            migrationBuilder.DropTable(
                name: "Usercourses");
        }
    }
}
