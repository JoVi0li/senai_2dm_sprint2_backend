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
            _ITipoHabilidadeRepository.Create(TipoHabilidadeNovo);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ITipoHabilidadeRepository.Read());
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_ITipoHabilidadeRepository.ReadById(Id));
        }

        [HttpPut("{Id}")]
        public IActionResult Put(TipoHabilidade TipoHabilidadeAtualizado, int Id)
        {
            _ITipoHabilidadeRepository.Update(TipoHabilidadeAtualizado, Id);

            return StatusCode(204);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _ITipoHabilidadeRepository.Delete(Id);

            return StatusCode(204);
        }
    }
}
