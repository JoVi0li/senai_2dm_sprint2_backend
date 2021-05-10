using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
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
        /// <returns>StatusCode 201 - Created</returns>
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
        /// <returns>Lista de clinicas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _IClinicaRepository.Read();

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma clinica pelo Id
        /// </summary>
        /// <param name="Id">Id da clinica buscada</param>
        /// <returns>Uma clinica</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                _IClinicaRepository.ReadById(Id);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualizada uma clinica
        /// </summary>
        /// <param name="ClinicaAtualizada">Objeto do tipo Clinica contendo as novas informações</param>
        /// <param name="Id">Id da clinica bsucada</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(Clinica ClinicaAtualizada, int Id)
        {
            try
            {
                _IClinicaRepository.Update(ClinicaAtualizada, Id);

                return StatusCode(204);
            }
            catch (Exception ex )
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Exclui uma clinica
        /// </summary>
        /// <param name="Id">Id da clinica bsucada</param>
        /// <returns>StatusCode 204 - No Content</returns>
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
