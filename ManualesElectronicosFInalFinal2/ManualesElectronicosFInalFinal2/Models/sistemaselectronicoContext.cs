using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class sistemaselectronicoContext : DbContext
    {
        public sistemaselectronicoContext()
        {
        }

        public sistemaselectronicoContext(DbContextOptions<sistemaselectronicoContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Docentes> Docentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost; database=sistemaselectronico; password=root; user=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.ToTable("carrera");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Docentes>(entity =>
            {
                entity.ToTable("docentes");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("FkCarrera_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contraseña).HasColumnType("char(64)");

                entity.Property(e => e.Eliminado).HasColumnType("bit(1)");

                entity.Property(e => e.IdCarrera).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");

                entity.Property(e => e.NumeroDeControl).HasColumnType("char(64)");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Docentes)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkCarrera");
            });

            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.ToTable("alumnos");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("FkCarrera_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contraseña).HasColumnType("char(64)");

                entity.Property(e => e.Eliminado).HasColumnType("bit(1)");

                entity.Property(e => e.IdCarrera).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");

                entity.Property(e => e.NumeroControl).HasColumnType("char(64)");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carrera");
            });


        }
    }
}
