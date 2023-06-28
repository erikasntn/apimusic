using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicapi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhadString { get; set; }
        public byte[] SenhadSalt { get; set; }
        public byte[] SenhadHash { get; set; }
        public List<Musica> Favoritos { get; set; }
    }
}