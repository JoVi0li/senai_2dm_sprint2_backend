﻿using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "1")]
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
        [Authorize(Roles = "1")]
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
        [Authorize(Roles = "1")]
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


        [Authorize(Roles = "1, 2")]
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

        [Authorize(Roles = "1, 3")]
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
        [Authorize(Roles = "1")]
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
        [Authorize(Roles = "1")]
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
