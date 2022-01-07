﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VokabelTrainerAPI.Data;

#nullable disable

namespace VokabelTrainerAPI.Migrations
{
    [DbContext(typeof(VokabelTrainerAPIContext))]
    [Migration("20220103173232_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("VokabelTrainerAPI.Models.Sprache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sprache");
                });

            modelBuilder.Entity("VokabelTrainerAPI.Models.Vokabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abschnitt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpracheId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TypId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uebersetzung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Wort")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SpracheId");

                    b.HasIndex("TypId");

                    b.ToTable("Vokabel");
                });

            modelBuilder.Entity("VokabelTrainerAPI.Models.WortTyp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WortTyp");
                });

            modelBuilder.Entity("VokabelTrainerAPI.Models.Vokabel", b =>
                {
                    b.HasOne("VokabelTrainerAPI.Models.Sprache", "Sprache")
                        .WithMany("vokabels")
                        .HasForeignKey("SpracheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VokabelTrainerAPI.Models.WortTyp", "Typ")
                        .WithMany("vokabels")
                        .HasForeignKey("TypId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sprache");

                    b.Navigation("Typ");
                });

            modelBuilder.Entity("VokabelTrainerAPI.Models.Sprache", b =>
                {
                    b.Navigation("vokabels");
                });

            modelBuilder.Entity("VokabelTrainerAPI.Models.WortTyp", b =>
                {
                    b.Navigation("vokabels");
                });
#pragma warning restore 612, 618
        }
    }
}
