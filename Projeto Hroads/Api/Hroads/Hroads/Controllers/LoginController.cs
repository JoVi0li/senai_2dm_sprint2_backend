using Hroads.Domains;
using Hroads.Interfaces;
using Hroads.Repositories;
using Hroads.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hroads.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public LoginController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuario UsuarioBuscado = _UsuarioRepository.Login(login.Email, login.Senha);

                if (UsuarioBuscado == null)
                {
                    return NotFound("E-mail ou Senha inválidos!");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.EmailUsuario),

                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString())
                };

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Hroads-key"));

                var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Hroads.WebApi",
                    audience: "Hroads.WebApi",
                    claims: Claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: Creds
                    );


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


            }
            catch (Exception ex)
            {

                BadRequest(ex);
            };
            return Ok();
        }
    }
}
