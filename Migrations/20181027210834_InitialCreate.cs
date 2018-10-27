using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_blueview.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpeechRecognitions",
                columns: table => new
                {
                    SpeechRecognitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AudioUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeechRecognitions", x => x.SpeechRecognitionId);
                });

            migrationBuilder.CreateTable(
                name: "SpeechRecognitionAlternatives",
                columns: table => new
                {
                    SpeechRecognitionAlternativeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Transcript = table.Column<string>(nullable: true),
                    SpeechRecognitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeechRecognitionAlternatives", x => x.SpeechRecognitionAlternativeId);
                    table.ForeignKey(
                        name: "FK_SpeechRecognitionAlternatives_SpeechRecognitions_SpeechRecognitionId",
                        column: x => x.SpeechRecognitionId,
                        principalTable: "SpeechRecognitions",
                        principalColumn: "SpeechRecognitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordInfos",
                columns: table => new
                {
                    WordInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpeechRecognitionAlternativeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordInfos", x => x.WordInfoId);
                    table.ForeignKey(
                        name: "FK_WordInfos_SpeechRecognitionAlternatives_SpeechRecognitionAlternativeId",
                        column: x => x.SpeechRecognitionAlternativeId,
                        principalTable: "SpeechRecognitionAlternatives",
                        principalColumn: "SpeechRecognitionAlternativeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpeechRecognitionAlternatives_SpeechRecognitionId",
                table: "SpeechRecognitionAlternatives",
                column: "SpeechRecognitionId");

            migrationBuilder.CreateIndex(
                name: "IX_WordInfos_SpeechRecognitionAlternativeId",
                table: "WordInfos",
                column: "SpeechRecognitionAlternativeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordInfos");

            migrationBuilder.DropTable(
                name: "SpeechRecognitionAlternatives");

            migrationBuilder.DropTable(
                name: "SpeechRecognitions");
        }
    }
}
