﻿// <auto-generated />
using System;
using Example_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Example_API.Migrations
{
    [DbContext(typeof(StudyAppContext))]
    [Migration("20230120134555_FirstVersion")]
    partial class FirstVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Example_API.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libros");
                });
            modelBuilder.Entity("Example_API.Models.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("contenido");

                    b.Property<DateTime?>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("fecha")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdTarea")
                        .HasColumnType("int")
                        .HasColumnName("idTarea");

                    b.HasKey("Id");

                    b.HasIndex("IdTarea");

                    b.ToTable("notas", (string)null);
                });

            modelBuilder.Entity("Example_API.Models.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<bool>("Done")
                        .HasColumnType("bit")
                        .HasColumnName("done");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("tareas", (string)null);
                });

            modelBuilder.Entity("Example_API.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("Example_API.Models.Nota", b =>
                {
                    b.HasOne("Example_API.Models.Tarea", "IdTareaNavigation")
                        .WithMany("Nota")
                        .HasForeignKey("IdTarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Notas_Tareas");

                    b.Navigation("IdTareaNavigation");
                });

            modelBuilder.Entity("Example_API.Models.Tarea", b =>
                {
                    b.Navigation("Nota");
                });
#pragma warning restore 612, 618
        }
    }
}
