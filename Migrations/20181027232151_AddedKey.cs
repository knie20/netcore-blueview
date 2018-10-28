using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_blueview.Migrations
{
    public partial class AddedKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrimeReports",
                columns: table => new
                {
                    CrimeReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    CrimeCode = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    AudioUrl = table.Column<string>(nullable: true),
                    Transcript = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeReports", x => x.CrimeReportId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeReports");
        }
    }
}
