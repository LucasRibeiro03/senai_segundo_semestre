using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI.Livros.WebApi.Domains;
using SENAI.Livros.WebApi.Repositorys;

namespace SENAI.Livros.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();
        [HttpGet]
        public IEnumerable<GeneroDomain> ListarTodos()
        {
            return generoRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generodomain)
        {
            generoRepository.Cadastrar(generodomain);
            return Ok();
        }
    }
}