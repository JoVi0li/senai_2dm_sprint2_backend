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
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _IUsuarioRepository { get; set; }

        public UsuarioController()
        {
            _IUsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario UsuarioNovo)
        {
            _IUsuarioRepository.Create(UsuarioNovo);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IUsuarioRepository.Read());
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_IUsuarioRepository.ReadById(Id));
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Usuario UsuarioAtualizado, int Id)
        {
            _IUsuarioRepository.Update(UsuarioAtualizado, Id);

            return StatusCode(204);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _IUsuarioRepository.Delete(Id);

            return StatusCode(204);
        }
    }
}
