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
    [ApiController]
    public class ArtistaController : ControllerBase
    {

        public Artistas Artistas = new Artistas();
        ArtistaRepository artistaRepository = new ArtistaRepository();
        //Listar

        [HttpGet]
        public IActionResult Listar()
        {

            return Ok(artistaRepository.Listar());
        }

        //Adicionar

        [HttpPost]
        public void Cadastrar(Artistas artista)
        {
            artistaRepository.Cadastrar(artista);
        }

    }
}