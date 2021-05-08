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
            _HabilidadeRepository.Create(HabilidadeNovo);

            return StatusCode(201);
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_HabilidadeRepository.Read());
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_HabilidadeRepository.ReadById(Id));
        }


        [HttpPut("{Id}")]
        public IActionResult Put(Habilidade HabilidadeNovo, int Id)
        {
            _HabilidadeRepository.Update(HabilidadeNovo, Id);

            return StatusCode(204);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _HabilidadeRepository.Delete(Id);

            return StatusCode(204);
        }
    }
}
