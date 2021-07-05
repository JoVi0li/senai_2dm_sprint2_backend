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
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1, 2, 3")]
    public class ConsultumController : ControllerBase
    {
        private IConsultumRepository _IConsultumRepository { get; set; }

        public ConsultumController()
        {
            _IConsultumRepository = new ConsultumRepository();
        }


        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="NovoConsultum">Objeto do tipo Consultum</param>
        /// <returns>StatusCode 201 - Created</returns>
        
        [HttpPost]
        public IActionResult Post(Consultum NovoConsultum)
        {
            try
            {
                _IConsultumRepository.Create(NovoConsultum);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Uma lista de consultas</returns>      
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IConsultumRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca um consulta pelo Id
        /// </summary>
        /// <param name="Id">Id da consulta buscada</param>
        /// <returns>Uma consulta</returns>     
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IConsultumRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca as consultas atribuidas ao medico
        /// </summary>
        /// <param name="Id">Id do medico</param>
        /// <returns>Uma lista de consultas</returns>
        [HttpGet("GetByIdDoctor/{Id}")]
        public IActionResult GetByIdDoctor(int Id)
        {
            try
            {
                return Ok(_IConsultumRepository.ReadByIdDoctor(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca as consultas atribuidas ao paciente
        /// </summary>
        /// <param name="Id">Id do paciente</param>
        /// <returns>Uma lista de consultas</returns>
        ///     [Authorize(Roles = "1, 2, 3")]
        [HttpGet("GetByIdPatient/{Id}")]
        public IActionResult GetByIdPatient(int Id)
        {
            try
            {
                return Ok(_IConsultumRepository.ReadByIdPatient(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza as informações da consulta
        /// </summary>
        /// <param name="Id">Id da consulta buscada</param>
        /// <param name="ConsultumAtualizado">Objeto do tipo Consultum</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Consultum ConsultumAtualizado)
        {
            try
            {
                _IConsultumRepository.Update(Id, ConsultumAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Exclui uma consulta
        /// </summary>
        /// <param name="Id">Id da consulta buscada</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IConsultumRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
