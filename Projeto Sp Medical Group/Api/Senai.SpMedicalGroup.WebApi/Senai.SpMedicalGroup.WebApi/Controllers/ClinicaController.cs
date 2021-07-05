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
    [Authorize(Roles = "1")]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _IClinicaRepository { get; set; }

        public ClinicaController()
        {
            _IClinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="NovaClinica">Objeto do tipo Clinica</param>
        /// <returns>Status Code 201 - Created</returns>
 
        [HttpPost]
        public IActionResult Post(Clinica NovaClinica)
        {
            try
            {
                _IClinicaRepository.Create(NovaClinica);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }


        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas E Status Code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IClinicaRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
           
        }


        /// <summary>
        /// Busca um clinica pelo ID
        /// </summary>
        /// <param name="Id">Id da clinica buscada</param>
        /// <returns>A clinica buscada E Status Code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IClinicaRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            
        }


        /// <summary>
        /// Atualiza as informações de uma clinica
        /// </summary>
        /// <param name="Id">Id da clinica buscada</param>
        /// <param name="ClinicaAtualizada">Objeto tipo Clinica</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, Clinica ClinicaAtualizada)
        {
            try
            {
                _IClinicaRepository.Update(Id, ClinicaAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui uma clinica
        /// </summary>
        /// <param name="Id">Id da clinica buscada</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IClinicaRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
