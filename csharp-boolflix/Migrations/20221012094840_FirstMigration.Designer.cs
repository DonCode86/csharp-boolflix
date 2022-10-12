﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using csharp_boolflix.Context;

#nullable disable

namespace csharp_boolflix.Migrations
{
    [DbContext(typeof(BoolflixDbContext))]
    [Migration("20221012094840_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("ActorMediaInfo", b =>
                {
                    b.Property<int>("CastId")
                        .HasColumnType("int");

                    b.Property<int>("MediaInfosId")
                        .HasColumnType("int");

                    b.HasKey("CastId", "MediaInfosId");

                    b.HasIndex("MediaInfosId");

                    b.ToTable("ActorMediaInfo");
                });

            modelBuilder.Entity("Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<int>("TVSeriesId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisualizationCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TVSeriesId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("FeatureMediaInfo", b =>
                {
                    b.Property<int>("FeaturesId")
                        .HasColumnType("int");

                    b.Property<int>("MediaInfosId")
                        .HasColumnType("int");

                    b.HasKey("FeaturesId", "MediaInfosId");

                    b.HasIndex("MediaInfosId");

                    b.ToTable("FeatureMediaInfo");
                });

            modelBuilder.Entity("Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("PegiId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisualizationCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PegiId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("GenreMediaInfo", b =>
                {
                    b.Property<int>("GeneresId")
                        .HasColumnType("int");

                    b.Property<int>("MediaInfosId")
                        .HasColumnType("int");

                    b.HasKey("GeneresId", "MediaInfosId");

                    b.HasIndex("MediaInfosId");

                    b.ToTable("GenreMediaInfo");
                });

            modelBuilder.Entity("MediaInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<int?>("TvSeriesId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId")
                        .IsUnique()
                        .HasFilter("[FilmId] IS NOT NULL");

                    b.HasIndex("TvSeriesId")
                        .IsUnique()
                        .HasFilter("[TvSeriesId] IS NOT NULL");

                    b.ToTable("MediaInfos");
                });

            modelBuilder.Entity("Pegi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pegis");
                });

            modelBuilder.Entity("TVSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("PegiId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisualizationCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PegiId");

                    b.ToTable("TvSeries");
                });

            modelBuilder.Entity("ActorMediaInfo", b =>
                {
                    b.HasOne("Actor", null)
                        .WithMany()
                        .HasForeignKey("CastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaInfo", null)
                        .WithMany()
                        .HasForeignKey("MediaInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Episode", b =>
                {
                    b.HasOne("TVSeries", "TVSerie")
                        .WithMany("Episodes")
                        .HasForeignKey("TVSeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TVSerie");
                });

            modelBuilder.Entity("FeatureMediaInfo", b =>
                {
                    b.HasOne("Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaInfo", null)
                        .WithMany()
                        .HasForeignKey("MediaInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Film", b =>
                {
                    b.HasOne("Pegi", "Pegi")
                        .WithMany("Films")
                        .HasForeignKey("PegiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pegi");
                });

            modelBuilder.Entity("GenreMediaInfo", b =>
                {
                    b.HasOne("Genre", null)
                        .WithMany()
                        .HasForeignKey("GeneresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaInfo", null)
                        .WithMany()
                        .HasForeignKey("MediaInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MediaInfo", b =>
                {
                    b.HasOne("Film", "Film")
                        .WithOne("MediaInfo")
                        .HasForeignKey("MediaInfo", "FilmId");

                    b.HasOne("TVSeries", "tVSeries")
                        .WithOne("MediaInfo")
                        .HasForeignKey("MediaInfo", "TvSeriesId");

                    b.Navigation("Film");

                    b.Navigation("tVSeries");
                });

            modelBuilder.Entity("TVSeries", b =>
                {
                    b.HasOne("Pegi", null)
                        .WithMany("TVSeries")
                        .HasForeignKey("PegiId");
                });

            modelBuilder.Entity("Film", b =>
                {
                    b.Navigation("MediaInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("Pegi", b =>
                {
                    b.Navigation("Films");

                    b.Navigation("TVSeries");
                });

            modelBuilder.Entity("TVSeries", b =>
                {
                    b.Navigation("Episodes");

                    b.Navigation("MediaInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
