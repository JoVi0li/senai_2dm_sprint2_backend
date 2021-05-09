using Hroads.Domains;
using Hroads.Interfaces;
using Hroads.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabilidadeController : ControllerBase
    {

        private ITipoHabilidadeRepository _ITipoHabilidadeRepository { get; set; }


        public TipoHabilidadeController()
        {
            _ITipoHabilidadeRepository = new TipoHabilidadeRepository();
        }


        [HttpPost]
        public IActionResult Post(TipoHabilidade TipoHabilidadeNovo)
        {
            try
            {
                _ITipoHabilidadeRepository.Create(TipoHabilidadeNovo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ITipoHabilidadeRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_ITipoHabilidadeRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(TipoHabilidade TipoHabilidadeAtualizado, int Id)
        {
            try
            {
                _ITipoHabilidadeRepository.Update(TipoHabilidadeAtualizado, Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _ITipoHabilidadeRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
