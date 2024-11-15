using Microsoft.AspNetCore.Mvc;
using BingoAPI.Services;
using BingoAPI.DTOs;
using BingoAPI.Factories;
using BingoAPI.Database;
using System.Collections.Generic;

namespace BingoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SorteiosController : ControllerBase
    {
        private readonly ISorteioService _service;

        public SorteiosController(BingoDbContext context)
        {
            _service = SorteioFactoryMethod.CreateSorteioService(context);
        }

        // GET: /Sorteios
        [HttpGet]
        public ActionResult<IEnumerable<SorteioDto>> GetAll()
        {
            var sorteios = _service.GetAllSorteios();
            return Ok(sorteios);
        }

        // GET: /Sorteios/{id}
        [HttpGet("{id}")]
        public ActionResult<SorteioDto> GetById(int id)
        {
            var sorteio = _service.GetSorteioById(id);
            if (sorteio == null)
            {
                return NotFound();
            }
            return Ok(sorteio);
        }

        // POST: /Sorteios
        [HttpPost]
        public ActionResult<SorteioDto> Create(SorteioDto sorteioDto)
        {
            var createdSorteio = _service.RealizarSorteio(sorteioDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSorteio.Id }, createdSorteio);
        }

        // PUT: /Sorteios/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, SorteioDto sorteioDto)
        {
            if (id != sorteioDto.Id)
            {
                return BadRequest();
            }

            _service.UpdateSorteio(sorteioDto);
            return NoContent();
        }

        // DELETE: /Sorteios/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteSorteio(id);
            return NoContent();
        }
    }
}
