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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }


        [HttpPost]
        public IActionResult Post(Habilidade HabilidadeNovo)
        {
            try
            {
                _HabilidadeRepository.Create(HabilidadeNovo);

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
                return Ok(_HabilidadeRepository.Read());
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
                return Ok(_HabilidadeRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        [HttpPut("{Id}")]
        public IActionResult Put(Habilidade HabilidadeNovo, int Id)
        {
            try
            {
                _HabilidadeRepository.Update(HabilidadeNovo, Id);

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
                _HabilidadeRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
