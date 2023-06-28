﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using musicapi.Data;

#nullable disable

namespace musicapi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230621002104_MigracaoAlteracaoClasses")]
    partial class MigracaoAlteracaoClasses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("musicapi.Models.Musica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Artista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duracao")
                        .HasColumnType("time");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Musicas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Speak Now",
                            Artista = "Taylor Swift",
                            Duracao = new TimeSpan(0, 0, 5, 53, 0),
                            Genero = "Country",
                            Titulo = "Enchanted"
                        },
                        new
                        {
                            Id = 2,
                            Album = "Red Moon in Venus",
                            Artista = "Kali Uchis",
                            Duracao = new TimeSpan(0, 0, 3, 7, 0),
                            Genero = "R&B",
                            Titulo = "Moonlight"
                        },
                        new
                        {
                            Id = 3,
                            Album = "QVVJFA?",
                            Artista = "Baco Exu do Blues",
                            Duracao = new TimeSpan(0, 0, 3, 13, 0),
                            Genero = "Hip-Hop",
                            Titulo = "20 ligações"
                        },
                        new
                        {
                            Id = 4,
                            Album = "Dos Prédios Deluxe",
                            Artista = "Veigh",
                            Duracao = new TimeSpan(0, 0, 2, 20, 0),
                            Genero = "Trap",
                            Titulo = "Novo Balanço"
                        });
                });

            modelBuilder.Entity("musicapi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("musicapi.Models.Musica", b =>
                {
                    b.HasOne("musicapi.Models.Usuario", null)
                        .WithMany("Favoritos")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("musicapi.Models.Usuario", b =>
                {
                    b.Navigation("Favoritos");
                });
#pragma warning restore 612, 618
        }
    }
}