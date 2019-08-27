using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json ")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstiloRepositories estiloRepositories = new EstiloRepositories();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estiloRepositories.Listar());
        }
        [HttpPost]
        public IActionResult Adicionar(Estilos estilo)
        {
            try
            {
                estiloRepositories.Atualizar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Vish tente Again! " + ex.Message });
                
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Estilos estilos = estiloRepositories.BuscarPorId(Id);
            if (estilos == null)
                return NotFound();
            return Ok();
        }
    }
}