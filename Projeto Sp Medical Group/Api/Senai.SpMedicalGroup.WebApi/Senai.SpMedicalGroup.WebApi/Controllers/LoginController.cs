using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.SpMedicalGroup.WebApi.Domains;
using Senai.SpMedicalGroup.WebApi.Interfaces;
using Senai.SpMedicalGroup.WebApi.Repositories;
using Senai.SpMedicalGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _IUsuarioRepository { get; set; }


        public LoginController()
        {
            _IUsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Válida o email e senha para efetuar login E Gera um token caso o login seja efetuado
        /// </summary>
        /// <param name="Login"> >Objeto do tipo LoginViewModel</param>
        /// <returns>StatusCode 200 - Ok E token</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel Login)
        {
            try
            {
                Usuario UsuarioBuscado = _IUsuarioRepository.Login(Login.Email, Login.Senha);

                if (UsuarioBuscado == null)
                {
                    return NotFound("E-mail ou Senha inválidos!");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString()),

                    new Claim("Role", UsuarioBuscado.IdTipoUsuario.ToString()),

                    new Claim(JwtRegisteredClaimNames.Name, UsuarioBuscado.Nome)
                };

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SpMedicalGroup-Autenticacao"));

                var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "SpMedicalGroup.WebApi",
                    audience: "SpMedicalGroup.WebApi",
                    claims: Claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: Creds
                    );


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex )
            {

                return BadRequest(ex);
            }
        }
    }
}
