﻿// <auto-generated />
using System;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kol2.Migrations
{
    [DbContext(typeof(MusicDBContext))]
    [Migration("20220614121831_baza")]
    partial class baza
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kol2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Szprycer",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2017, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "Polska Floryda",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Kol2.Models.MusicLabel", b =>
                {
                    b.Property<int>("IDmusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDmusicLabel");

                    b.ToTable("MusicLabel");

                    b.HasData(
                        new
                        {
                            IDmusicLabel = 1,
                            Name = "QUEQALITY"
                        },
                        new
                        {
                            IDmusicLabel = 2,
                            Name = "Sony Music Polska"
                        });
                });

            modelBuilder.Entity("Kol2.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musician");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Filip",
                            LastName = "Szczesniak",
                            Nickname = "Taco Hemigway"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Tymoteusz",
                            LastName = "Rożynek",
                            Nickname = "Szczyl"
                        },
                        new
                        {
                            IdMusician = 3,
                            FirstName = "Michał",
                            LastName = "Matczak",
                            Nickname = "Mata"
                        });
                });

            modelBuilder.Entity("Kol2.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.HasKey("IdTrack", "IdMusician");

                    b.HasIndex("IdMusician");

                    b.ToTable("Musician_Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 2,
                            IdMusician = 2
                        },
                        new
                        {
                            IdTrack = 3,
                            IdMusician = 3
                        });
                });

            modelBuilder.Entity("Kol2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 6f,
                            IdMusicAlbum = 1,
                            TrackName = "Kabriolety"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 4.25f,
                            IdMusicAlbum = 2,
                            TrackName = "Hiphopkryta"
                        },
                        new
                        {
                            IdTrack = 3,
                            Duration = 4.25f,
                            TrackName = "Schodki"
                        });
                });

            modelBuilder.Entity("Kol2.Models.Album", b =>
                {
                    b.HasOne("Kol2.Models.MusicLabel", "MusicLabel")
                        .WithMany("albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("Kol2.Models.Musician_Track", b =>
                {
                    b.HasOne("Kol2.Models.Musician", "musician")
                        .WithMany("musician_tracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kol2.Models.Track", "track")
                        .WithMany("musician_tracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("musician");

                    b.Navigation("track");
                });

            modelBuilder.Entity("Kol2.Models.Track", b =>
                {
                    b.HasOne("Kol2.Models.Album", "album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("album");
                });

            modelBuilder.Entity("Kol2.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Kol2.Models.MusicLabel", b =>
                {
                    b.Navigation("albums");
                });

            modelBuilder.Entity("Kol2.Models.Musician", b =>
                {
                    b.Navigation("musician_tracks");
                });

            modelBuilder.Entity("Kol2.Models.Track", b =>
                {
                    b.Navigation("musician_tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
