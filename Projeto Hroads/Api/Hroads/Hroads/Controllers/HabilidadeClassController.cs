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
            _HabilidadeClassRepository.Create(HabilidadeClassNovo);

            return StatusCode(201);
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_HabilidadeClassRepository.Read());
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_HabilidadeClassRepository.ReadById(Id));
        }


        [HttpPut("{Id}")]
        public IActionResult Put(HabilidadeClass HabilidadeClassAtualizado,int Id)
        {
            _HabilidadeClassRepository.Update(HabilidadeClassAtualizado, Id);

            return StatusCode(204);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _HabilidadeClassRepository.Delete(Id);

            return StatusCode(204);
        }
    }
}
