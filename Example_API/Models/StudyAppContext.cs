using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Example_API.Models
{
    public partial class StudyAppContext : DbContext
    {
        public StudyAppContext()
        {
        }

        public StudyAppContext(DbContextOptions<StudyAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nota> Notas { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        public virtual DbSet<Libro> Libros {get ; set ;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=StudyApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nota>(entity =>
            {
                entity.ToTable("notas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contenido");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdTarea).HasColumnName("idTarea");

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdTarea)
                    .HasConstraintName("FK_Notas_Tareas");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("tareas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Done).HasColumnName("done");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
