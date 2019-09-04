using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI.Autopecas.WebApi.Domains;
using SENAI.Autopecas.WebApi.Interfaces; 
using SENAI.Autopecas.WebApi.Repositories;

namespace SENAI.Autopecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private IFornecedorRepository FornecedorRepository { get; set; }

        public FornecedorController()
        {
            FornecedorRepository = new FornecedorRepository();
        }

        //listar
        [Authorize]
        [HttpGet] public IActionResult Listar()
        {
            return Ok(FornecedorRepository.listar());
        }
        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Fornecedores fornecedor)
        {
            try
            {
                int UsuarioId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                fornecedor.IdUsuario = UsuarioId;

                FornecedorRepository.Cadastrar(fornecedor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
                
            }
        }
        //deletar
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id )
        {
            FornecedorRepository.Deletar(id);
            return Ok();
        }
        //atualizar
        [Authorize]
        [HttpPut]
        public IActionResult Atualizar(Fornecedores fornecedor)
        {
            try
            {
                Fornecedores fornecedoresBuscados = FornecedorRepository.BuscarPorId(fornecedor.IdFornecedor);
                if (fornecedoresBuscados == null)
                {
                    return NotFound();
                }
                FornecedorRepository.Atualizar(fornecedor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message});
                
            }
        }
        //buscar por id
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Fornecedores fornecedor = FornecedorRepository.BuscarPorId(id);
            if (fornecedor == null)
            {
                return NotFound();
            }return Ok(fornecedor);
        }
    }
}