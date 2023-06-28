using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musicapi.Data;
using musicapi.Models;
using musicapi.Utils;

namespace musicapi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var usuario = await _context.Usuarios.ToListAsync();
            return Ok(usuario);
        }

        private async Task<bool> UsuarioExistente(string Nome)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Nome.ToLower() == Nome.ToLower()))
            {
                return true;
            }
            return false;

        }

        [HttpPut]
        public async Task<IActionResult> Update(Usuario novoNome)
        {
            try
            {

                _context.Usuarios.Update(novoNome);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Nome.ToLower().Equals(credenciais.Nome.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia
                .VerificarPasswordHash(credenciais.SenhadString, usuario.SenhadHash, usuario.SenhadSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario nome)
        {
            try
            {
                if (await UsuarioExistente(nome.Nome))
                    throw new System.Exception("Nome de usuário já existe");
                Criptografia.CriarPasswordHash(nome.SenhadString, out byte[] hash, out byte[] salt);
                nome.SenhadString = string.Empty;
                nome.SenhadHash = hash;
                nome.SenhadSalt = salt;
                await _context.Usuarios.AddAsync(nome);
                await _context.SaveChangesAsync();

                return Ok(nome.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

}