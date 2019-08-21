using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Senai.Filmes.WebApi.GenerosController
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GenerosRepositories GenerosRepositories = new GenerosRepositories();
          
        [HttpGet]
        public IEnumerable<GeneroDomain> ListarTodos()
        {
            return GeneroRepositories.Listar();
        }
        
    }
}