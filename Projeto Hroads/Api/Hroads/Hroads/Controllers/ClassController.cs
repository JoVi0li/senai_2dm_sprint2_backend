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
    public class ClassController : ControllerBase
    {

        private IClassRepository _IClassRepository { get; set; }

        public ClassController()
        {
            _IClassRepository = new ClassRepository();
        }

        [HttpPost]
        public IActionResult Post(Class ClassNovo)
        {
            _IClassRepository.Create(ClassNovo);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IClassRepository.Read());
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_IClassRepository.ReadById(Id));
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Class ClassAtualizado, int Id)
        {
            _IClassRepository.Update(ClassAtualizado, Id);

            return StatusCode(204);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _IClassRepository.Delete(Id);

            return StatusCode(204);
        }
    }
}
