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
    public class PersonagenController : ControllerBase
    {
        private IPersonagenRepository _IPersonagenRepository { get; set; }
        
        public PersonagenController()
        {
            _IPersonagenRepository = new PersonagenRepository();
        }


        [HttpPost]
        public IActionResult Post(Personagen PersonagenNovo)
        {
            _IPersonagenRepository.Create(PersonagenNovo);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IPersonagenRepository.Read());
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_IPersonagenRepository.ReadById(Id));
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Personagen PersonagenNovo, int Id)
        {
            _IPersonagenRepository.Update(PersonagenNovo, Id);

            return StatusCode(204);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _IPersonagenRepository.Delete(Id);

            return StatusCode(204);
        }
    }
}
