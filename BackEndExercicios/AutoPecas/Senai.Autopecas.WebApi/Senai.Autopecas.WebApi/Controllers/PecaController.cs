using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class PecaController : ControllerBase
    {
        private IPecasRepository PecasRepository { get; set; }

        public PecaController()
        {
            PecasRepository = new PecasRepository();
        }
        //listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecasRepository.Listar());
        }
        //buscar por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pecas peca = PecasRepository.BuscarPorId(id);
            if (peca == null)
            {
                return NotFound();
            }
            return Ok(peca);
        }

        //cadastrar

        //atualizar

        //deletar


        //Fazer Controller
        //Parei aqui :)
    }
}