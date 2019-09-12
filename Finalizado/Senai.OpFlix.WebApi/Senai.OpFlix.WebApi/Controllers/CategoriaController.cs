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
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriaController()
        {
            CategoriaRepository = new CategoriaRepository();
        }


        //listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.listar());
        }



        //buscar por id

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias categoria = CategoriaRepository.BuscarPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }


        //cadastrar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias Categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(Categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });

            }
        }




        //atualizar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                Categorias categoriaBuscada = CategoriaRepository.BuscarPorId(categoria.IdCategoria);
                if (categoriaBuscada == null)
                {
                    return NotFound();
                }
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message});
            }
        }



        //deletar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CategoriaRepository.Deletar(id);
            return Ok();
        }
    }
}