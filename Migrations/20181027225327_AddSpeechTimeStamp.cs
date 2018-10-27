using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netcore_blueview.Migrations
{
    public partial class AddSpeechTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "SpeechRecognitions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "SpeechRecognitions");
        }
    }
}
