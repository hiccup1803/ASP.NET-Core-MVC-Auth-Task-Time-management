using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyReportVersionOne.Migrations
{
    /// <inheritdoc />
    public partial class Newtablesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Upwork = table.Column<int>(type: "int", nullable: false),
                    Freelancer = table.Column<int>(type: "int", nullable: false),
                    Workana = table.Column<int>(type: "int", nullable: false),
                    Crowdwork = table.Column<int>(type: "int", nullable: false),
                    OtherSite = table.Column<int>(type: "int", nullable: false),
                    BidRecordDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPrice = table.Column<int>(type: "int", nullable: false),
                    ClientCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectState = table.Column<int>(type: "int", nullable: false),
                    ProjectStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjectRecordDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Studies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyRecordDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Studies");
        }
    }
}
