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
    [Authorize]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _IEspecialiadeRepository { get; set; }

        public EspecialidadeController()
        {
            _IEspecialiadeRepository = new EspecialidadeRepository();
        }


        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="NovaEspecialidade">Objeto do tipo Especialidade</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Especialidade NovaEspecialidade)
        {
            try
            {
                _IEspecialiadeRepository.Create(NovaEspecialidade);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns>Uma lista de especialidades E StatusCode 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IEspecialiadeRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }



        /// <summary>
        /// Busca uma especialidade pelo Id
        /// </summary>
        /// <param name="Id">Id da especialidade buscada</param>
        /// <returns>Uma especialidade E StatusCode 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IEspecialiadeRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        /// <summary>
        /// Atualiza as informações de uma especialidade
        /// </summary>
        /// <param name="Id">Id da especialidade buscada</param>
        /// <param name="EspecialidadeAtualizada">objeto do tipo Especialidade</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, Especialidade EspecialidadeAtualizada)
        {
            try
            {
                _IEspecialiadeRepository.Update(Id, EspecialidadeAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui uma especialidade
        /// </summary>
        /// <param name="Id">Id da especialidade buscada</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IEspecialiadeRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
