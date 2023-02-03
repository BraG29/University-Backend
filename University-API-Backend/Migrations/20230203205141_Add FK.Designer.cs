﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University_API_Backend.DataAcces;

#nullable disable

namespace University_API_Backend.Migrations
{
    [DbContext(typeof(UniversityDBContext))]
    [Migration("20230203205141_Add FK")]
    partial class AddFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoriaCurso", b =>
                {
                    b.Property<int>("categoriasId")
                        .HasColumnType("int");

                    b.Property<int>("cursosId")
                        .HasColumnType("int");

                    b.HasKey("categoriasId", "cursosId");

                    b.HasIndex("cursosId");

                    b.ToTable("CategoriaCurso");
                });

            modelBuilder.Entity("CursoEstudiante", b =>
                {
                    b.Property<int>("cursosId")
                        .HasColumnType("int");

                    b.Property<int>("estudiantesId")
                        .HasColumnType("int");

                    b.HasKey("cursosId", "estudiantesId");

                    b.HasIndex("estudiantesId");

                    b.ToTable("CursoEstudiante");
                });

            modelBuilder.Entity("University_API_Backend.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("created_by");

                    b.HasIndex("deleted_by");

                    b.HasIndex("updated_by");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("University_API_Backend.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<string>("descripcionCorta")
                        .IsRequired()
                        .HasMaxLength(260)
                        .HasColumnType("nvarchar(260)");

                    b.Property<string>("descripcionLarga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("indiceId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("nivel")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("objetivos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("publicoObjetivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("requisitos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("created_by");

                    b.HasIndex("deleted_by");

                    b.HasIndex("indiceId")
                        .IsUnique();

                    b.HasIndex("updated_by");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("University_API_Backend.Models.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaNac")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("created_by");

                    b.HasIndex("deleted_by");

                    b.HasIndex("updated_by");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("University_API_Backend.Models.Indice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<int>("idCurso")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("created_by");

                    b.HasIndex("deleted_by");

                    b.HasIndex("updated_by");

                    b.ToTable("Indices");
                });

            modelBuilder.Entity("University_API_Backend.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("created_by")
                        .HasColumnType("int");

                    b.Property<int?>("deleted_by")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("updated_by")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("created_by");

                    b.HasIndex("deleted_by");

                    b.HasIndex("updated_by");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CategoriaCurso", b =>
                {
                    b.HasOne("University_API_Backend.Models.Categoria", null)
                        .WithMany()
                        .HasForeignKey("categoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_API_Backend.Models.Curso", null)
                        .WithMany()
                        .HasForeignKey("cursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CursoEstudiante", b =>
                {
                    b.HasOne("University_API_Backend.Models.Curso", null)
                        .WithMany()
                        .HasForeignKey("cursosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_API_Backend.Models.Estudiante", null)
                        .WithMany()
                        .HasForeignKey("estudiantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("University_API_Backend.Models.Categoria", b =>
                {
                    b.HasOne("University_API_Backend.Models.Usuario", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("created_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_API_Backend.Models.Usuario", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("deleted_by");

                    b.HasOne("University_API_Backend.Models.Usuario", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("updated_by");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("University_API_Backend.Models.Curso", b =>
                {
                    b.HasOne("University_API_Backend.Models.Usuario", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("created_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_API_Backend.Models.Usuario", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("deleted_by");

                    b.HasOne("University_API_Backend.Models.Indice", "indice")
                        .WithOne("curso")
                        .HasForeignKey("University_API_Backend.Models.Curso", "indiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_API_Backend.Models.Usuario", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("updated_by");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");

                    b.Navigation("indice");
                });

            modelBuilder.Entity("University_API_Backend.Models.Estudiante", b =>
                {
                    b.HasOne("University_API_Backend.Models.Usuario", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("created_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_API_Backend.Models.Usuario", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("deleted_by");

                    b.HasOne("University_API_Backend.Models.Usuario", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("updated_by");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("University_API_Backend.Models.Indice", b =>
                {
                    b.HasOne("University_API_Backend.Models.Usuario", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("created_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_API_Backend.Models.Usuario", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("deleted_by");

                    b.HasOne("University_API_Backend.Models.Usuario", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("updated_by");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("University_API_Backend.Models.Usuario", b =>
                {
                    b.HasOne("University_API_Backend.Models.Usuario", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("created_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("University_API_Backend.Models.Usuario", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("deleted_by");

                    b.HasOne("University_API_Backend.Models.Usuario", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("updated_by");

                    b.Navigation("CreatedBy");

                    b.Navigation("DeletedBy");

                    b.Navigation("UpdatedBy");
                });

            modelBuilder.Entity("University_API_Backend.Models.Indice", b =>
                {
                    b.Navigation("curso")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
