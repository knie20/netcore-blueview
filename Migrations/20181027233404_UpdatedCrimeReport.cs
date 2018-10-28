using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_blueview.Migrations
{
    public partial class UpdatedCrimeReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "CrimeReports");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "CrimeReports");

            migrationBuilder.DropColumn(
                name: "Transcript",
                table: "CrimeReports");

            migrationBuilder.AddColumn<int>(
                name: "SpeechRecognitionId",
                table: "CrimeReports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CrimeReports_SpeechRecognitionId",
                table: "CrimeReports",
                column: "SpeechRecognitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrimeReports_SpeechRecognitions_SpeechRecognitionId",
                table: "CrimeReports",
                column: "SpeechRecognitionId",
                principalTable: "SpeechRecognitions",
                principalColumn: "SpeechRecognitionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrimeReports_SpeechRecognitions_SpeechRecognitionId",
                table: "CrimeReports");

            migrationBuilder.DropIndex(
                name: "IX_CrimeReports_SpeechRecognitionId",
                table: "CrimeReports");

            migrationBuilder.DropColumn(
                name: "SpeechRecognitionId",
                table: "CrimeReports");

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "CrimeReports",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "CrimeReports",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Transcript",
                table: "CrimeReports",
                nullable: true);
        }
    }
}
