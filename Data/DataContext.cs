using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using musicapi.Models;
using musicapi.Utils;
namespace musicapi.Data
{
    public class  DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Musica>().HasData
           (
            new Musica() { Id = 1, Titulo = "Enchanted", Artista = "Taylor Swift", Album = "Speak Now", Genero = "Country", Duracao = TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(53)) },
            new Musica() { Id = 2, Titulo = "Moonlight", Artista = "Kali Uchis", Album = "Red Moon in Venus", Genero = "R&B", Duracao = TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(07)) },
            new Musica() { Id = 3, Titulo = "20 ligações", Artista = "Baco Exu do Blues", Album = "QVVJFA?", Genero = "Hip-Hop", Duracao = TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(13)) },
            new Musica() { Id = 4, Titulo = "Novo Balanço", Artista = "Veigh", Album = "Dos Prédios Deluxe", Genero = "Trap", Duracao = TimeSpan.FromMinutes(2).Add(TimeSpan.FromSeconds(20)) }
           );
           Usuario user = new Usuario();
           Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[]salt);
           user.Id = 1;
           user.Nome = "Erika";
           user.SenhadString = string.Empty;
           user.SenhadHash = hash;
           user.SenhadSalt = salt;
           user.Email = "Erika@gmail.com";

           modelBuilder.Entity<Usuario>().HasData(user);

        }
    }
}