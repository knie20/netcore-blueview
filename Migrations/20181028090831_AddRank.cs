using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_blueview.Migrations
{
    public partial class AddRank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrimeReports_SpeechRecognitionResponses_SpeechRecognitionResponseId",
                table: "CrimeReports");

            migrationBuilder.DropIndex(
                name: "IX_CrimeReports_SpeechRecognitionResponseId",
                table: "CrimeReports");

            migrationBuilder.RenameColumn(
                name: "SpeechRecognitionResponseId",
                table: "CrimeReports",
                newName: "AlternativeId");

            migrationBuilder.AddColumn<float>(
                name: "Confidence",
                table: "Alternatives",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "CrimeReportId",
                table: "Alternatives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Alternatives",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_CrimeReports_CrimeReportId",
                table: "Alternatives");

            migrationBuilder.DropIndex(
                name: "IX_Alternatives_CrimeReportId",
                table: "Alternatives");

            migrationBuilder.DropColumn(
                name: "Confidence",
                table: "Alternatives");

            migrationBuilder.DropColumn(
                name: "CrimeReportId",
                table: "Alternatives");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Alternatives");

            migrationBuilder.RenameColumn(
                name: "AlternativeId",
                table: "CrimeReports",
                newName: "SpeechRecognitionResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeReports_SpeechRecognitionResponseId",
                table: "CrimeReports",
                column: "SpeechRecognitionResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrimeReports_SpeechRecognitionResponses_SpeechRecognitionResponseId",
                table: "CrimeReports",
                column: "SpeechRecognitionResponseId",
                principalTable: "SpeechRecognitionResponses",
                principalColumn: "SpeechRecognitionResponseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
