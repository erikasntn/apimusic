using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musicapi.Data;
using musicapi.Models;


namespace musicapi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MusicaController : ControllerBase
    {

        private static List<Musica> musicas = new List<Musica>()
        {
            new Musica() { Id = 1, Titulo = "Enchanted", Artista = "Taylor Swift", Album = "Speak Now", Genero = "Country", Duracao = TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(53)) },
            new Musica() { Id = 2, Titulo = "Moonlight", Artista = "Kali Uchis", Album = "Red Moon in Venus", Genero = "R&B", Duracao = TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(07)) },
            new Musica() { Id = 3, Titulo = "20 ligações", Artista = "Baco Exu do Blues", Album = "QVVJFA?", Genero = "Hip-Hop", Duracao = TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(13)) },
            new Musica() { Id = 4, Titulo = "Novo Balanço", Artista = "Veigh", Album = "Dos Prédios Deluxe", Genero = "Trap", Duracao = TimeSpan.FromMinutes(2).Add(TimeSpan.FromSeconds(20)) }
        };
        private readonly DataContext _context;

        public MusicaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var musicas = await _context.Musicas.ToListAsync();
            return Ok(musicas);
        }

        [HttpPost("AddMusic")]
        public async Task<IActionResult> AddMusic(Musica novaMusica)
        {
            var existingMusica = await _context.Musicas.Where(x=> x.Artista == novaMusica.Artista && x.Titulo == novaMusica.Titulo).ToListAsync();

            if (existingMusica.Count != 0)
            {
                return BadRequest("A música já foi adicionada anteriormente.");
            }

            _context.Musicas.Add(novaMusica);
            await _context.SaveChangesAsync();

            var musicas = await _context.Musicas.ToListAsync();
            return Ok(musicas);
        }


      [HttpGet("GetById/{id}")]
     public async Task<IActionResult> GetById(int id)
        {
            var listaBuscaId = await _context.Musicas.Where(m => m.Id == id).ToListAsync();
            return Ok(listaBuscaId);
        }

        [HttpDelete("DeleteById/{id}")]
public async Task<IActionResult> DeleteById(int id)
{
    try
    {
        Musica musicaRemover = await _context.Musicas.FirstOrDefaultAsync(m => m.Id == id);

        if (musicaRemover == null)
        {
            return NotFound();
        }

        _context.Musicas.Remove(musicaRemover);
        int linhasAfetadas = await _context.SaveChangesAsync();

        return Ok(linhasAfetadas);
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message);
    }
}



    }
}



