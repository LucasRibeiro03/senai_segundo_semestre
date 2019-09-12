using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private IPlataformaRepository plataformaRepository { get; set; }

        public PlataformaController()
        {
            plataformaRepository = new PlataformaRepository();
        }

        //listar

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(plataformaRepository.listar());
        }

        //cadastrar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            try
            {
                plataformaRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });

            }
        }
        //buscar por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Plataformas plataforma = plataformaRepository.BuscarPorId(id);
            if (plataforma == null)
            {
                return NotFound();
            }
            return Ok(plataforma);
        }

        //atualizar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Plataformas plataforma)
        {
            try
            {
                Plataformas PlataformaBuscada = plataformaRepository.BuscarPorId(plataforma.IdPlataforma);
                if (PlataformaBuscada == null)
                {
                    return NotFound();
                }
                plataformaRepository.Atualizar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        //deletar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            plataformaRepository.Deletar(id);
            return Ok();
        }
    }
}