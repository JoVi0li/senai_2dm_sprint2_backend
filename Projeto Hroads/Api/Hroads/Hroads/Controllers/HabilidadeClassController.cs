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
    public class HabilidadeClassController : ControllerBase
    {
        private IHabilidadeClassRepository _HabilidadeClassRepository { get; set; }

        public HabilidadeClassController()
        {
            _HabilidadeClassRepository = new HabilidadeClassRepository();
        }


        [HttpPost]
        public IActionResult Post(HabilidadeClass HabilidadeClassNovo)
        {
            try
            {
                _HabilidadeClassRepository.Create(HabilidadeClassNovo);

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
                return Ok(_HabilidadeClassRepository.Read());
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
                return Ok(_HabilidadeClassRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        [HttpPut("{Id}")]
        public IActionResult Put(HabilidadeClass HabilidadeClassAtualizado,int Id)
        {
            try
            {
                _HabilidadeClassRepository.Update(HabilidadeClassAtualizado, Id);

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
                _HabilidadeClassRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
