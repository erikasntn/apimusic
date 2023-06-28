using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicapi.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Artista { get; set; }

        public string Album { get; set; }
        public string Genero { get; set; }
        public TimeSpan Duracao { get; set; }
    }
}