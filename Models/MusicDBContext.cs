using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Models
{
    public class MusicDBContext : DbContext
    {
        public DbSet<Album> albums { get; set; }
        public DbSet<Musician> musicians { get; set; }
        public DbSet<Track> tracks { get; set; }
        public DbSet<Musician_Track> musician_Tracks { get; set; }
        public DbSet<MusicLabel> musicLabels { get; set; }

        public MusicDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var musicians = new List<Musician>
            {
                new Musician{ IdMusician = 1,FirstName = "Filip", LastName = "Szczesniak", Nickname = "Taco Hemigway"},
                new Musician{ IdMusician = 2,FirstName = "Tymoteusz", LastName = "Rożynek", Nickname = "Szczyl"},
                new Musician{ IdMusician = 3,FirstName = "Michał", LastName = "Matczak", Nickname = "Mata"},
                new Musician{ IdMusician = 4,FirstName = "Dawid", LastName = "Podsiadło", Nickname = null}
            };

            var musicLabels = new List<MusicLabel>
            {
                new MusicLabel{ IDmusicLabel = 1,Name = "QUEQALITY"},
                new MusicLabel{ IDmusicLabel = 2,Name = "Sony Music Polska"}
            };

            var Albums = new List<Album>
            {
                new Album{IdAlbum=1,AlbumName="Szprycer",PublishDate= new DateTime(2017,07,30), IdMusicLabel=1},
                new Album{IdAlbum=2,AlbumName="Polska Floryda",PublishDate= new DateTime(2021,10,15), IdMusicLabel=2}
            };

            var tracks = new List<Track>
            {
                new Track{ TrackName = "Kabriolety", Duration=6, IdTrack=1, IdMusicAlbum=1},
                new Track{ TrackName = "Hiphopkryta", Duration=4.25f, IdTrack=2,  IdMusicAlbum=2},
                new Track{ TrackName = "Schodki", Duration=4.25f, IdTrack=3,  IdMusicAlbum=null},
                new Track{ TrackName = "Ortalion", Duration=3.24f, IdTrack=4, IdMusicAlbum=null},
                new Track{ TrackName = "Małomiasteczkowy", Duration=3.24f, IdTrack=5, IdMusicAlbum=null},
            };

            var music_track = new List<Musician_Track>
            {
                new Musician_Track{IdMusician=1,IdTrack=1},
                new Musician_Track{IdMusician=2,IdTrack=2},
                new Musician_Track{IdMusician=3,IdTrack=3},
                new Musician_Track{IdMusician=1,IdTrack=4},
                new Musician_Track{IdMusician=4,IdTrack=5}
            };

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(20).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.HasData(musicians);
                e.ToTable("Musician");
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.HasKey(e => new { e.IdTrack , e.IdMusician});

                e.HasOne(e => e.musician)
                .WithMany(e => e.musician_tracks)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(e => e.track)
                .WithMany(e => e.musician_tracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasData(music_track);
                e.ToTable("Musician_Track");
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.ClientSetNull); ;

                e.HasData(tracks);
                e.ToTable("Track");
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired().HasColumnType("datetime"); ;

                e.HasOne(e => e.MusicLabel)
               .WithMany(e => e.albums)
               .HasForeignKey(e => e.IdMusicLabel)
               .OnDelete(DeleteBehavior.Cascade);

                e.HasData(Albums);
                e.ToTable("Album");
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IDmusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.HasData(musicLabels);
                e.ToTable("MusicLabel");
            });
        }
    }
}
