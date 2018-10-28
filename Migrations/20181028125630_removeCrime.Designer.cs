﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using netcore_blueview.Models;

namespace netcore_blueview.Migrations
{
    [DbContext(typeof(DAO))]
    [Migration("20181028125630_removeCrime")]
    partial class removeCrime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("netcore_blueview.Models.Alternative", b =>
                {
                    b.Property<int>("AlternativeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Confidence");

                    b.Property<int>("Rank");

                    b.Property<int>("SpeechRecognitionResultId");

                    b.Property<string>("Transcript");

                    b.HasKey("AlternativeId");

                    b.HasIndex("SpeechRecognitionResultId");

                    b.ToTable("Alternatives");
                });

            modelBuilder.Entity("netcore_blueview.Models.SpeechRecognitionResponse", b =>
                {
                    b.Property<int>("SpeechRecognitionResponseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudioUrl");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("SpeechRecognitionResponseId");

                    b.ToTable("SpeechRecognitionResponses");
                });

            modelBuilder.Entity("netcore_blueview.Models.SpeechRecognitionResult", b =>
                {
                    b.Property<int>("SpeechRecognitionResultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SpeechRecognitionResponseId");

                    b.HasKey("SpeechRecognitionResultId");

                    b.HasIndex("SpeechRecognitionResponseId");

                    b.ToTable("SpeechRecognitionResults");
                });

            modelBuilder.Entity("netcore_blueview.Models.WordInfo", b =>
                {
                    b.Property<int>("WordInfoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlternativeId");

                    b.HasKey("WordInfoId");

                    b.HasIndex("AlternativeId");

                    b.ToTable("WordInfos");
                });

            modelBuilder.Entity("netcore_blueview.Models.Alternative", b =>
                {
                    b.HasOne("netcore_blueview.Models.SpeechRecognitionResult", "SpeechRecognitionResult")
                        .WithMany("Alternatives")
                        .HasForeignKey("SpeechRecognitionResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("netcore_blueview.Models.SpeechRecognitionResult", b =>
                {
                    b.HasOne("netcore_blueview.Models.SpeechRecognitionResponse", "SpeechRecognitionResponse")
                        .WithMany("SpeechRecognitionResults")
                        .HasForeignKey("SpeechRecognitionResponseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("netcore_blueview.Models.WordInfo", b =>
                {
                    b.HasOne("netcore_blueview.Models.Alternative", "Alternative")
                        .WithMany("WordInfos")
                        .HasForeignKey("AlternativeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
