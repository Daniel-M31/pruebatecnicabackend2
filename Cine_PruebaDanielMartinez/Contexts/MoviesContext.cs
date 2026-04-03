using System;
using System.Collections.Generic;
using Cine_PruebaDanielMartinez.Models;
using Microsoft.EntityFrameworkCore;

namespace Cine_PruebaDanielMartinez.Contexts;

public partial class MoviesContext : DbContext
{
    public MoviesContext()
    {
    }

    public MoviesContext(DbContextOptions<MoviesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<pelicula> peliculas { get; set; }

    public virtual DbSet<pelicula_sala_cine> pelicula_sala_cines { get; set; }

    public virtual DbSet<sala_cine> sala_cines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-HMS8UH0\\SQLEXPRESS;Database= cine_db;User ID=sa;Password=sa;Trusted_Connection=False;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<pelicula>(entity =>
        {
            entity.HasKey(e => e.id_pelicula).HasName("PK__pelicula__B5017F4D71B071B5");

            entity.ToTable("pelicula");

            entity.Property(e => e.estado).HasDefaultValue(true);
            entity.Property(e => e.nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<pelicula_sala_cine>(entity =>
        {
            entity.HasKey(e => e.id_pelicula_sala).HasName("PK__pelicula__39BC477F21605B45");

            entity.ToTable("pelicula_sala_cine");

            entity.Property(e => e.estado).HasDefaultValue(true);

            entity.HasOne(d => d.id_peliculaNavigation).WithMany(p => p.pelicula_sala_cines)
                .HasForeignKey(d => d.id_pelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeliculaSala_Pelicula");

            entity.HasOne(d => d.id_salaNavigation).WithMany(p => p.pelicula_sala_cines)
                .HasForeignKey(d => d.id_sala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeliculaSala_Sala");
        });

        modelBuilder.Entity<sala_cine>(entity =>
        {
            entity.HasKey(e => e.id_sala).HasName("PK__sala_cin__D18B015BDC4D2665");

            entity.ToTable("sala_cine");

            entity.Property(e => e.estado).HasDefaultValue(true);
            entity.Property(e => e.nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
