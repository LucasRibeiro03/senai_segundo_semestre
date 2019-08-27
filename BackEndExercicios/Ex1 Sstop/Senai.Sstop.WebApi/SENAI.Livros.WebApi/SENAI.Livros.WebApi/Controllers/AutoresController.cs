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
    public class AutoresController : ControllerBase
    {
        AutoresRepository AutoresRepository = new AutoresRepository();

        [HttpGet]
        public IEnumerable<AutoresDomain> ListarTodos()
        {
            return AutoresRepository.Listar();
        }
        [HttpPost]
        public IActionResult Adicionar(AutoresDomain autoresdomain){
            AutoresRepository.Cadastrar(autoresdomain);
            return Ok();
        } 


    }
}