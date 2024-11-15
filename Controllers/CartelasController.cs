using Microsoft.AspNetCore.Mvc;
using BingoAPI.Services;
using BingoAPI.Factories;
using BingoAPI.Models;
using BingoAPI.Database;
using BingoAPI.DTOs;

namespace BingoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartelasController : ControllerBase
    {
        private readonly ICartelaService _service;

        public CartelasController(BingoDbContext context)
        {
            _service = CartelasFactoryMethod.CreateCartelaService(context);
        }

        [HttpGet]
        public IActionResult GetCartelas()
        {
            var cartelas = _service.GetAllCartelas();
            return Ok(cartelas);
        }

        [HttpGet("{id}")]
        public IActionResult GetCartela(int id)
        {
            var cartela = _service.GetCartelaById(id);
            if (cartela == null)
            {
                return NotFound();
            }
            return Ok(cartela);
        }

        [HttpPost]
        public IActionResult CreateCartela([FromBody] CartelaDto cartelaDto) // Aceita apenas NomeJogador
        {
            if (cartelaDto == null || string.IsNullOrEmpty(cartelaDto.NomeJogador))
            {
                return BadRequest();
            }

            // Gera números aleatórios para a cartela
            cartelaDto.Números = GerarNumerosAleatorios();

            _service.CreateCartela(cartelaDto);
            return CreatedAtAction(nameof(GetCartela), new { id = cartelaDto.Id }, cartelaDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCartela(int id, [FromBody] CartelaDto cartelaDto)
        {
            if (cartelaDto == null || cartelaDto.Id != id)
            {
                return BadRequest();
            }

            _service.UpdateCartela(cartelaDto);
            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCartela(int id)
        {
            _service.DeleteCartela(id);
            return NoContent(); // 204 No Content
        }

        private List<int> GerarNumerosAleatorios()
        {
            var numeros = new HashSet<int>();
            Random random = new Random();

            while (numeros.Count < 15) // Supondo que você queira 15 números únicos
            {
                numeros.Add(random.Next(1, 76)); // Ajuste o intervalo conforme necessário
            }

            return numeros.ToList();
        }
    }
}
