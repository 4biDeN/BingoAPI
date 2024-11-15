using BingoAPI.DTOs;
using System.Collections.Generic;

namespace BingoAPI.Repositories
{
    // Interface do repositório que define os métodos para verificar ganhadores
    public interface IGanhadorRepository
    {
        // Método para verificar se uma cartela é vencedora com base nos números sorteados
        bool VerificarGanhador(List<int> numerosSorteados, CartelaDto cartela);

        // Método para obter todas as cartelas vencedoras
        List<CartelaDto> ObterGanhadores(List<int> numerosSorteados, IEnumerable<CartelaDto> cartelas);
    }
}
