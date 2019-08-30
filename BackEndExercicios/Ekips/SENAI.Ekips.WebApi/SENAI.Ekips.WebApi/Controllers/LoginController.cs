using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SENAI.Ekips.WebApi.Domains;
using SENAI.Ekips.WebApi.Repositories;
using SENAI.Ekips.WebApi.ViewModels;

namespace SENAI.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        FuncionarioRepository funcionariorepository = new FuncionarioRepository();





        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Funcionarios usuarioBuscado = funcionariorepository.BuscarPorEmailESenha(login);
                if (usuarioBuscado == null)
                    return NotFound(new { mensagem = "Email ou Senha Inválidos." });

                // informacoes referentes ao usuario
                var claims = new[]
               {
                    // chave customizada
                    new Claim("chave", "0123456789"),
                    new Claim("ribeiro", "AgoraFoi"),
                    // email
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.NomeFuncionario),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdFuncionario.ToString()),
                    // permissao
                    //new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ekips-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Ekips.WebApi",
                    audience: "Ekips.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar." + ex.Message });
            }
        }
    }
}