using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI.Ekips.WebApi.Domains;
using SENAI.Ekips.WebApi.Repositories;

namespace SENAI.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        Departamentos Departamentos = new Departamentos();

        DepartamentoRepository DepartamentoRepository = new DepartamentoRepository();

        //listar

        [HttpGet]
        public IActionResult listar()
        {
            return Ok(DepartamentoRepository.Listar());
        }

        //buscar por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Departamentos departamento = DepartamentoRepository.BuscarPorId(id);

            return Ok(departamento);
        }
        //adicionar
        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            DepartamentoRepository.cadastrar(departamento);
            return Ok(departamento);
        }
        //atualizar
        [HttpPut]

        //deletar
        [HttpDelete]

    }
}