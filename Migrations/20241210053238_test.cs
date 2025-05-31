using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMVCApplication.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    STFSTUDID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STFSTUDLNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STFSTUDFNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STFSTUDMNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STFSTUDCOURSE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STFSTUDYEAR = table.Column<int>(type: "int", nullable: false),
                    STFSTUDREMARKS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STFSTUDSTATUS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.STFSTUDID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SFSUBJCODE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SFSUBJDESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SFSUBJUNITS = table.Column<int>(type: "int", nullable: false),
                    SFSUBJREGOFRNG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SFSUBJCATEGORY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SFSUBJCOURSECODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SFSUBJREQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SFSUBJCODEREQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SFSUBJCURRICULUMCOURSECODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SFSUBJECTSTATUS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SFSUBJCODE);
                });

            migrationBuilder.CreateTable(
                name: "SubjectSchedule",
                columns: table => new
                {
                    SSFEDPCODE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SSFSUBJCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFSTARTTIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SSFENDTIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SSFDAYS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFROOM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFMAXSIZE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFCLASSSIZE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFSTATUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFXM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFSECTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFSCHOOLYEAR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSchedule", x => x.SSFEDPCODE);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STFSTUDID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SFSUBJCODE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SSFSUBJCODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFEDPCODE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSFSCHOOLYEAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFSTARTTIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SSFENDTIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SSFDAYS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFROOM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFMAXSIZE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFCLASSSIZE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFSTATUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFXM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSFSECTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_STFSTUDID",
                        column: x => x.STFSTUDID,
                        principalTable: "Student",
                        principalColumn: "STFSTUDID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Subject_SFSUBJCODE",
                        column: x => x.SFSUBJCODE,
                        principalTable: "Subject",
                        principalColumn: "SFSUBJCODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_SubjectSchedule_SSFEDPCODE",
                        column: x => x.SSFEDPCODE,
                        principalTable: "SubjectSchedule",
                        principalColumn: "SSFEDPCODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_SFSUBJCODE",
                table: "Enrollment",
                column: "SFSUBJCODE");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_SSFEDPCODE",
                table: "Enrollment",
                column: "SSFEDPCODE");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_STFSTUDID",
                table: "Enrollment",
                column: "STFSTUDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "SubjectSchedule");
        }
    }
}
