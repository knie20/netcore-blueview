using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_blueview.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpeechRecognitionResponses",
                columns: table => new
                {
                    SpeechRecognitionResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AudioUrl = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeechRecognitionResponses", x => x.SpeechRecognitionResponseId);
                });

            migrationBuilder.CreateTable(
                name: "CrimeReports",
                columns: table => new
                {
                    CrimeReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CrimeCode = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    SpeechRecognitionResponseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeReports", x => x.CrimeReportId);
                    table.ForeignKey(
                        name: "FK_CrimeReports_SpeechRecognitionResponses_SpeechRecognitionResponseId",
                        column: x => x.SpeechRecognitionResponseId,
                        principalTable: "SpeechRecognitionResponses",
                        principalColumn: "SpeechRecognitionResponseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeechRecognitionResults",
                columns: table => new
                {
                    SpeechRecognitionResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpeechRecognitionResponseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeechRecognitionResults", x => x.SpeechRecognitionResultId);
                    table.ForeignKey(
                        name: "FK_SpeechRecognitionResults_SpeechRecognitionResponses_SpeechRecognitionResponseId",
                        column: x => x.SpeechRecognitionResponseId,
                        principalTable: "SpeechRecognitionResponses",
                        principalColumn: "SpeechRecognitionResponseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternatives",
                columns: table => new
                {
                    AlternativeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Transcript = table.Column<string>(nullable: true),
                    SpeechRecognitionResultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternatives", x => x.AlternativeId);
                    table.ForeignKey(
                        name: "FK_Alternatives_SpeechRecognitionResults_SpeechRecognitionResultId",
                        column: x => x.SpeechRecognitionResultId,
                        principalTable: "SpeechRecognitionResults",
                        principalColumn: "SpeechRecognitionResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordInfos",
                columns: table => new
                {
                    WordInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlternativeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordInfos", x => x.WordInfoId);
                    table.ForeignKey(
                        name: "FK_WordInfos_Alternatives_AlternativeId",
                        column: x => x.AlternativeId,
                        principalTable: "Alternatives",
                        principalColumn: "AlternativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternatives_SpeechRecognitionResultId",
                table: "Alternatives",
                column: "SpeechRecognitionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_CrimeReports_SpeechRecognitionResponseId",
                table: "CrimeReports",
                column: "SpeechRecognitionResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeechRecognitionResults_SpeechRecognitionResponseId",
                table: "SpeechRecognitionResults",
                column: "SpeechRecognitionResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_WordInfos_AlternativeId",
                table: "WordInfos",
                column: "AlternativeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeReports");

            migrationBuilder.DropTable(
                name: "WordInfos");

            migrationBuilder.DropTable(
                name: "Alternatives");

            migrationBuilder.DropTable(
                name: "SpeechRecognitionResults");

            migrationBuilder.DropTable(
                name: "SpeechRecognitionResponses");
        }
    }
}
