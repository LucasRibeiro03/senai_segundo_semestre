using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optus2.Domains;
using Optus2.Repositories;

namespace Optus2.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstiloController : ControllerBase
    {
        EstiloRepository estiloRepository = new EstiloRepository();
        public Estilos Estilos = new Estilos();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estiloRepository.Listar());
        }
        [HttpGet]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(estiloRepository.BuscarPorId(id));
        }
        [HttpPost]
        public void Cadastrar (Estilos estilo)
        {
            estiloRepository.Cadastrar(estilo);
        }

        [HttpDelete("{id}")]
        public IActionResult deletar(int id)
        {
            estiloRepository.deletar(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult atualizar(Estilos estilo)
        {
            Estilos estiloBuscado = estiloRepository.BuscarPorId(Estilos.IdEstilo);
            if (estiloBuscado == null)
                return NotFound();

            estiloRepository.Atualizar(estilo);
            return Ok();
        }
    }
}