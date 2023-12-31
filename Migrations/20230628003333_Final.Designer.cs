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
    [Migration("20230628003333_Final")]
    partial class Final
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Artista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duracao")
                        .HasColumnType("time");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SenhadHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SenhadSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SenhadString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Erika@gmail.com",
                            Nome = "Erika",
                            SenhadHash = new byte[] { 168, 108, 32, 172, 127, 27, 253, 55, 170, 85, 236, 140, 143, 43, 136, 101, 254, 238, 93, 209, 94, 136, 148, 18, 118, 41, 41, 75, 91, 178, 102, 155, 31, 147, 67, 138, 81, 253, 156, 221, 153, 157, 132, 171, 209, 50, 185, 135, 179, 122, 87, 12, 142, 195, 58, 163, 20, 244, 117, 17, 191, 222, 42, 174 },
                            SenhadSalt = new byte[] { 171, 218, 20, 100, 79, 95, 61, 215, 216, 7, 132, 58, 240, 185, 144, 96, 100, 221, 45, 116, 186, 147, 210, 144, 63, 120, 242, 92, 36, 172, 96, 187, 197, 34, 157, 210, 143, 13, 156, 120, 186, 240, 147, 14, 54, 96, 51, 167, 43, 159, 255, 28, 107, 131, 143, 17, 180, 198, 169, 156, 28, 142, 67, 119, 55, 155, 193, 152, 114, 179, 167, 1, 159, 148, 77, 125, 204, 137, 41, 24, 134, 0, 101, 178, 240, 222, 198, 79, 191, 14, 230, 231, 28, 231, 20, 73, 220, 187, 26, 239, 20, 219, 207, 65, 245, 126, 79, 69, 133, 175, 211, 169, 167, 120, 248, 134, 74, 10, 45, 141, 193, 47, 203, 19, 243, 89, 205, 10 },
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
