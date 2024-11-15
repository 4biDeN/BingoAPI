using BingoAPI.DTOs;
using System.Collections.Generic;

namespace BingoAPI.Services
{
    // Interface que define as operações para o serviço de sorteio
    public interface ISorteioService
    {
        SorteioDto RealizarSorteio(SorteioDto sorteio); // Realiza um novo sorteio
        IEnumerable<SorteioDto> GetAllSorteios(); // Obtém todos os sorteios
        SorteioDto GetSorteioById(int id); // Obtém um sorteio pelo ID
        void UpdateSorteio(SorteioDto sorteio); // Atualiza um sorteio
        void DeleteSorteio(int id); // Deleta um sorteio pelo ID
        List<int> ObterNumerosSorteados(); // Obtém números sorteados
    }
}
