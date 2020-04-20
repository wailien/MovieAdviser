﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MovieAdviser.DataAccess.Entities;

namespace MovieAdviser.DataAccess.Context
{
    public partial class GenreContext : DbContext
    {
        public GenreContext()
        {
        }
        public GenreContext(DbContextOptions<GenreContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Cartoon> Cartoon { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(g => g.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(g => g.Name).IsRequired();
                entity.Property(g => g.Description).IsRequired();
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(m => m.Name).IsRequired();
                entity.Property(m => m.Year).IsRequired();
                entity.Property((m => m.Director)).IsRequired();
                entity.Property((m => m.Rating)).IsRequired();
                entity.HasOne(s => s.Genre)
                    .WithMany(g => g.Movie)
                    .HasForeignKey(s => s.GenreId)
                    .HasConstraintName("FK_Movie_Genre");
            });
            
            modelBuilder.Entity<Cartoon>(entity =>
            {
                entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Year).IsRequired();
                entity.HasOne(s => s.Genre)
                    .WithMany(g => g.Cartoon)
                    .HasForeignKey(s => s.GenreId)
                    .HasConstraintName("FK_Cartoon_Genre");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}