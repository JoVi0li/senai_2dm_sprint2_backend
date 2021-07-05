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
    [Authorize(Roles = "2, 1, 3")]
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _IProntuarioRepository { get; set; }

        public ProntuarioController()
        {
            _IProntuarioRepository = new ProntuarioRepository();
        }


        /// <summary>
        /// Cadastra um novo prontuario
        /// </summary>
        /// <param name="NovoProntuario">Objeto do tipo Prontuario</param>
        /// <returns>StatusCode 201 - Created</returns>
       
        [HttpPost]
        public IActionResult Post(Prontuario NovoProntuario)
        {
            try
            {
                _IProntuarioRepository.Create(NovoProntuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todos os prontuarios
        /// </summary>
        /// <returns>Uma lista de prontuarios E StatusCode 200 - Ok</returns>
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IProntuarioRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um prontuario pelo ID
        /// </summary>
        /// <param name="Id">Id do prontuario buscado</param>
        /// <returns>Um prontuario E StatusCode 200 - Ok</returns>
        
        [HttpGet("{Id}")]
        public IActionResult GetbyId(int Id)
        {
            try
            {
                return Ok(_IProntuarioRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza as informações de um prontuario
        /// </summary>
        /// <param name="Id">Id do prontuario buscado</param>
        /// <param name="ProntuarioAtualizado">objeto do tipo Prontuario</param>
        /// <returns>StatusCode 204 - No Content</returns>
        
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Prontuario ProntuarioAtualizado)
        {
            try
            {
                _IProntuarioRepository.Update(Id, ProntuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui um prontuario
        /// </summary>
        /// <param name="Id">Id do prontuario buscado</param>
        /// <returns>StatusCode 204 - No Content</returns>
        
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IProntuarioRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
