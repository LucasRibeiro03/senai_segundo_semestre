using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI.Livros.WebApi.Repositorys;

namespace SENAI.Livros.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        LivroRepository livroRepository = new LivroRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(livroRepository.Listar());
        }

    }
}