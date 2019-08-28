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
    public class CargoController : ControllerBase
    {
        Cargos cargo = new Cargos();
        CargosRepository cargosRepository = new CargosRepository();

        //listar
        [HttpGet]
        public IActionResult Listar()
        {

            return Ok(cargosRepository.Listar());
        }
        //buscar por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargos cargo = cargosRepository.BuscarPorId(id);

            if (cargo == null)
                return NotFound();
            return Ok(cargo);
        }
        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            try
            {
                cargosRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "errou!" + ex.Message });
            }
        }
        //atualizar
        [HttpPut]
        public IActionResult Atualizar()
        {
            try
            {
                Cargos CargoEncontrado = cargosRepository.BuscarPorId(cargo.IdCargo);

                if (CargoEncontrado == null)
                    return NotFound();
                cargosRepository.Atualizar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Errooou!" + ex.Message });
            }
        }
        //deletar
        [HttpDelete("{id}")]
        public IActionResult deletar(int id)
        {
            cargosRepository.Deletar(id);
            return Ok();
        }
    }
}