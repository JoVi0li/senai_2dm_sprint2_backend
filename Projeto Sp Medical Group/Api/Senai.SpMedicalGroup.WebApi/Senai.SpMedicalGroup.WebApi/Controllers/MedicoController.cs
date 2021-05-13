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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _IMedicoRepository { get; set; }

        public MedicoController()
        {
            _IMedicoRepository = new MedicoRepository();
        }


        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="NovoMedico">Objeto do tipo Medico</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Medico NovoMedico)
        {
            try
            {
                _IMedicoRepository.Create(NovoMedico);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Uma lista de medicos && StatusCode 200 - Ok</returns>
        [HttpGet]
        public IActionResult Red()
        {
            try
            {
                return Ok(_IMedicoRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca um medico pelo Id
        /// </summary>
        /// <param name="Id">Id do medico buscado</param>
        /// <returns>Um medico && StatusCode 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IMedicoRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza as informações do medico
        /// </summary>
        /// <param name="Id">Id do medico buscado</param>
        /// <param name="MedicoAtualizado">Objeto do tipo Medico</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Medico MedicoAtualizado)
        {
            try
            {
                _IMedicoRepository.Update(Id, MedicoAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui um medico
        /// </summary>
        /// <param name="Id">Id do medico buscado</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IMedicoRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
