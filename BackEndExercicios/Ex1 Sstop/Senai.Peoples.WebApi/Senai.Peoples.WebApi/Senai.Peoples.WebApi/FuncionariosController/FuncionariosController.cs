using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.FuncionariosDomains;
using Senai.Peoples.WebApi.FuncionariosRepository;

namespace Senai.Peoples.WebApi.FuncionariosController
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();


        FuncionariosRepositorio funcionariosRepositorio = new FuncionariosRepositorio();

        [HttpGet]
         public IEnumerable<FuncionariosDomain> ListarTodos()
        {
            return funcionariosRepositorio.Listar();
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionariosDomain funcionario = funcionariosRepositorio.BuscarPorId(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }
        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain funcionarioDomain)
        {
            funcionariosRepositorio.Cadastrar(funcionarioDomain);
            return Ok();
           

        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionariosRepositorio.Deletar(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar(FuncionariosDomain funcionarioDomain)
        {
            funcionariosRepositorio.Atualizar(funcionarioDomain);
            return Ok();
        }


    }
}