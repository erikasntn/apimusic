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
    [Migration("20230621180450_MigrationPermitirNulo")]
    partial class MigrationPermitirNulo
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

                    b.Property<byte[]>("SenhadHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SenhadSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SenhadString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Erika@gmail.com",
                            Nome = "Erika",
                            SenhadHash = new byte[] { 71, 56, 156, 185, 211, 206, 179, 73, 3, 224, 195, 217, 123, 77, 100, 55, 212, 137, 206, 187, 245, 167, 31, 142, 110, 140, 13, 96, 8, 46, 239, 169, 138, 122, 162, 53, 140, 69, 172, 94, 32, 158, 9, 187, 188, 209, 91, 181, 32, 209, 140, 233, 10, 43, 36, 178, 72, 158, 184, 215, 199, 92, 129, 109 },
                            SenhadSalt = new byte[] { 163, 64, 170, 49, 251, 48, 4, 191, 13, 205, 220, 55, 220, 183, 117, 155, 181, 107, 234, 90, 27, 201, 225, 253, 196, 210, 12, 44, 183, 171, 94, 69, 190, 220, 108, 67, 176, 231, 21, 127, 216, 35, 145, 218, 17, 137, 76, 100, 127, 5, 171, 165, 132, 206, 219, 139, 204, 39, 21, 0, 67, 71, 222, 213, 9, 147, 90, 17, 207, 212, 84, 133, 32, 197, 68, 149, 117, 230, 65, 82, 230, 61, 249, 192, 31, 166, 68, 8, 200, 108, 95, 103, 98, 176, 76, 108, 178, 225, 185, 65, 75, 180, 168, 142, 211, 58, 74, 100, 250, 161, 178, 118, 132, 97, 219, 238, 164, 19, 85, 205, 45, 114, 26, 226, 230, 182, 163, 164 },
                            SenhadString = ""
                        });
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