using System.Collections.Generic;
using BingoAPI.DTOs;

namespace BingoAPI.Services
{
    // Interface do serviço que define os métodos para operar com ganhadores
    public interface IGanhadorService
    {
        // Método para verificar se uma cartela é vencedora
        bool VerificarGanhador(List<int> numerosSorteados, CartelaDto cartela);

        // Método para obter todas as cartelas vencedoras
        List<CartelaDto> ObterGanhadores(List<int> numerosSorteados, IEnumerable<CartelaDto> cartelas);
    }
}
