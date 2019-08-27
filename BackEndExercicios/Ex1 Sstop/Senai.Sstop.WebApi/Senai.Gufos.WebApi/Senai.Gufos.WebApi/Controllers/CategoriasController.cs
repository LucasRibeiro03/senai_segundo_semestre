using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository CategoriaRepository = new CategoriaRepository();
        [HttpGet]
        //IEnumeramble
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro: " + ex.Message });
            };

        }
        [HttpGet("{id}")]
        public IActionResult buscarporid(int id)
        {
            Categorias categoria = CategoriaRepository.BuscarPorId(id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CategoriaRepository.Deletar(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                //pesquisar uma categoria
                Categorias categoriaBuscada = CategoriaRepository.BuscarPorId
                    (categoria.IdCategoria);
                //caso não incontre , not found
                if (categoriaBuscada == null)
                    return NotFound();
                //caso contrario, se ela for encontrada, eu atualizo pq eu quero
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Vish tente again!"});
            }
        }
    }
}