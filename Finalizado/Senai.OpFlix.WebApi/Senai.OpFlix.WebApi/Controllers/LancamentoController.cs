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
    public class LancamentoController : ControllerBase
    {
        private ILancamentoRepository lancamentoRepository { get; set; }

        public LancamentoController()
        {
            lancamentoRepository = new LancamentoRepository();
        }
        
        //Listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(lancamentoRepository.listar());
        }
        //deletar
        [Authorize(Roles ="ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            lancamentoRepository.Deletar(id);
            return Ok();
        }

        //Cadastrar
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            try
            {
                lancamentoRepository.Cadastrar(lancamento);
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
        public IActionResult Atualizar(Lancamentos lancamento)
        {
            try
            {
                Lancamentos lancamentoBuscado = lancamentoRepository.BuscarPorId(lancamento.IdLancamento);
                if (lancamentoBuscado == null)
                {
                    return NotFound();
                }
                lancamentoRepository.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception ex )
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }
        //Buscar Por Id

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Lancamentos lancamento = lancamentoRepository.BuscarPorId(id);
            if (lancamento == null)
            {
                return NotFound();
            }
            return Ok(lancamento);
        }
    
    }
}