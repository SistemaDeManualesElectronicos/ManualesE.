using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManualesElectronicosFInalFinal2.Models
{
    public partial class sistemaelectronico123Context : DbContext
    {
        public sistemaelectronico123Context()
        {
        }

        public sistemaelectronico123Context(DbContextOptions<sistemaelectronico123Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Docentes> Docentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;database=sistemaelectronico123;user=root;password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Docentes>(entity =>
            {
                entity.ToTable("docentes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Carrera).HasColumnType("varchar(45)");

                entity.Property(e => e.Contraseña).HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(45)");

                entity.Property(e => e.NumeroDeControl).HasColumnType("varchar(45)");
            });
        }
    }
}
