using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    //json está falando que essa será a saida
    [Produces("application/json")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        // repositorio
        EventoRepository EventoRepository = new EventoRepository();
        // endpoints
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EventoRepository.Listar());
        }
    }
}