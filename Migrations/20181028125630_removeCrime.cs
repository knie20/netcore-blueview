using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_blueview.Migrations
{
    public partial class removeCrime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_CrimeReports_CrimeReportId",
                table: "Alternatives");

            migrationBuilder.DropTable(
                name: "CrimeReports");

            migrationBuilder.DropIndex(
                name: "IX_Alternatives_CrimeReportId",
                table: "Alternatives");

            migrationBuilder.DropColumn(
                name: "CrimeReportId",
                table: "Alternatives");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrimeReportId",
                table: "Alternatives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CrimeReports",
                columns: table => new
                {
                    CrimeReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlternativeId = table.Column<int>(nullable: false),
                    CrimeCode = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeReports", x => x.CrimeReportId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternatives_CrimeReportId",
                table: "Alternatives",
                column: "CrimeReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alternatives_CrimeReports_CrimeReportId",
                table: "Alternatives",
                column: "CrimeReportId",
                principalTable: "CrimeReports",
                principalColumn: "CrimeReportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
