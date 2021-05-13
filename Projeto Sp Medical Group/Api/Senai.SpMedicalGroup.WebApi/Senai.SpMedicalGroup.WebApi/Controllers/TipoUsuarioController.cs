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
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _ITipoUsuarioRepository { get; set; }


        public TipoUsuarioController()
        {
            _ITipoUsuarioRepository = new TipoUsuarioRepository();
        }


        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="NovoTipoUsuario">Objeto do tipo TipoUsuario</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario NovoTipoUsuario)
        {
            try
            {
                _ITipoUsuarioRepository.Create(NovoTipoUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns>Uma lista de tipos de usuarios && StatusCode 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ITipoUsuarioRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca um tipo de usuario pelo Id
        /// </summary>
        /// <param name="Id">Id do tipo de usuario buscado</param>
        /// <returns>Um tipo de usuario && StatusCode 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_ITipoUsuarioRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza as informações de um tipo de usuario
        /// </summary>
        /// <param name="Id">id do tipo de usuario buscado</param>
        /// <param name="TpoUsuarioAtualizado">Objeto do tipo TipoUsuario</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, TipoUsuario TpoUsuarioAtualizado)
        {
            try
            {
                _ITipoUsuarioRepository.Update(Id, TpoUsuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui um tipo de usuario
        /// </summary>
        /// <param name="Id">Id do tipo de usuario buscado</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _ITipoUsuarioRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
