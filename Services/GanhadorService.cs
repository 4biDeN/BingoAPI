using System.Collections.Generic;
using BingoAPI.DTOs;
using BingoAPI.Repositories;

namespace BingoAPI.Services
{
    // Implementação do serviço que usa o repositório para lógica de negócios
    public class GanhadorService : IGanhadorService
    {
        // Dependência do repositório de ganhadores, injetada via construtor
        private readonly IGanhadorRepository _ganhadorRepository;

        // Construtor que recebe o repositório de ganhadores, promovendo a injeção de dependência
        public GanhadorService(IGanhadorRepository ganhadorRepository)
        {
            _ganhadorRepository = ganhadorRepository;
        }

        // Método que verifica se uma cartela é vencedora usando o repositório
        public bool VerificarGanhador(List<int> numerosSorteados, CartelaDto cartela)
        {
            // Encaminha a chamada para o método do repositório
            return _ganhadorRepository.VerificarGanhador(numerosSorteados, cartela);
        }

        // Método que obtém todas as cartelas vencedoras usando o repositório
        public List<CartelaDto> ObterGanhadores(List<int> numerosSorteados, IEnumerable<CartelaDto> cartelas)
        {
            // Encaminha a chamada para o método do repositório
            return _ganhadorRepository.ObterGanhadores(numerosSorteados, cartelas);
        }
    }
}
