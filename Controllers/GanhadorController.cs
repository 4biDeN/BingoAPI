using Microsoft.AspNetCore.Mvc;
using BingoAPI.Services;
using BingoAPI.Factories;
using BingoAPI.Database;
using BingoAPI.DTOs;
using System.Collections.Generic;

namespace BingoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GanhadorController : ControllerBase
    {
        private readonly IGanhadorService _service;

        public GanhadorController(BingoDbContext context)
        {
            _service = GanhadorFabricMethod.CreateGanhadorService(context);
        }

        [HttpPost("verificar")]
        public IActionResult VerificarGanhador([FromBody] VerificarCartelaRequest request)
        {
            if (request == null || request.NumerosSorteados == null || request.Cartela == null)
            {
                return BadRequest("Requisição inválida.");
            }

            var vencedor = _service.VerificarGanhador(request.NumerosSorteados, request.Cartela);
            return Ok(new { Vencedor = vencedor });
        }

        [HttpPost("obter-ganhadores")]
        public IActionResult ObterGanhadores([FromBody] ObterGanhadoresRequest request)
        {
            if (request == null || request.NumerosSorteados == null || request.Cartelas == null)
            {
                return BadRequest("Requisição inválida.");
            }

            var ganhadores = _service.ObterGanhadores(request.NumerosSorteados, request.Cartelas);
            return Ok(ganhadores);
        }
    }

    /// <summary>
    /// Classe para representar o request do endpoint de verificação.
    /// </summary>
    public class VerificarCartelaRequest
    {
        public List<int> NumerosSorteados { get; set; }
        public CartelaDto Cartela { get; set; }
    }

    /// <summary>
    /// Classe para representar o request do endpoint de obtenção de ganhadores.
    /// </summary>
    public class ObterGanhadoresRequest
    {
        public List<int> NumerosSorteados { get; set; }
        public List<CartelaDto> Cartelas { get; set; }
    }
}
