using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameMania.DataAcccessLayer.Models
{
    public partial class GameManiaContext : DbContext
    {
        public GameManiaContext()
        {
        }

        public GameManiaContext(DbContextOptions<GameManiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BoardGame> BoardGames { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardGame>(entity =>
            {
                entity.ToTable("Board_Games");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BggRank).HasColumnName("BGG_Rank");

                entity.Property(e => e.ComplexityAverage)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("Complexity_Average");

                entity.Property(e => e.Domains)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.MaxPlayers).HasColumnName("Max_Players");

                entity.Property(e => e.Mechanics)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.MinAge).HasColumnName("Min_Age");

                entity.Property(e => e.MinPlayers).HasColumnName("Min_Players");

                entity.Property(e => e.Name)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OwnedUsers).HasColumnName("Owned_Users");

                entity.Property(e => e.PlayTime).HasColumnName("Play_Time");

                entity.Property(e => e.RatingAverage)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("Rating_Average");

                entity.Property(e => e.UsersRated).HasColumnName("Users_Rated");

                entity.Property(e => e.YearPublished).HasColumnName("Year_Published");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Platform)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("platform");

                entity.Property(e => e.ReleaseDate)
                    .HasMaxLength(50)
                    .HasColumnName("release_date");

                entity.Property(e => e.Summary)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("summary");

                entity.Property(e => e.UserReview).HasColumnName("user_review");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
