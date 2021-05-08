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
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _ITipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _ITipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario TipoUsuarioNovo)
        {
            _ITipoUsuarioRepository.Create(TipoUsuarioNovo);

            return StatusCode(201);
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ITipoUsuarioRepository.Read());
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_ITipoUsuarioRepository.ReadById(Id));
        }

        [HttpPut("{Id}")]
        public IActionResult Put(TipoUsuario TipoUsuarioAtualizado,int Id)
        {
            _ITipoUsuarioRepository.Update(TipoUsuarioAtualizado, Id);

            return StatusCode(204);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _ITipoUsuarioRepository.Delete(Id);

            return StatusCode(204);
        }

    }
}
