using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedicalGroup.WebApi.Domains;
using Senai.SpMedicalGroup.WebApi.Interfaces;
using Senai.SpMedicalGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _IUsuarioRepository { get; set; }


        public UsuarioController()
        {
            _IUsuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovoUsuario">Objeto do tipo Usuario</param>
        /// <returns>StatusCode 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario NovoUsuario)
        {
            try
            {
                _IUsuarioRepository.Create(NovoUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios E StatusCode 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IUsuarioRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca um usuario pelo Id
        /// </summary>
        /// <param name="Id">Id do usuario buscado</param>
        /// <returns>Um usuario E StatusCode 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IUsuarioRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza as informações de um usuario
        /// </summary>
        /// <param name="Id">Id do usuario buscado</param>
        /// <param name="UsuarioAtualizado">Objeto do tipo Usuario</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Usuario UsuarioAtualizado)
        {
            try
            {
                _IUsuarioRepository.Update(Id, UsuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui um usuario
        /// </summary>
        /// <param name="Id">Id do usuario buscado</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IUsuarioRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
