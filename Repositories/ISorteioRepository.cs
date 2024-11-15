using BingoAPI.DTOs;
using System.Collections.Generic;

namespace BingoAPI.Repositories
{
    // Interface que define operações de repositório para sorteios
    public interface ISorteioRepository
    {
        IEnumerable<SorteioDto> GetAll(); // Método para obter todos os sorteios
        SorteioDto GetById(int id); // Método para obter um sorteio por ID
        void Add(SorteioDto sorteio); // Método para adicionar um novo sorteio
        void Update(SorteioDto sorteio); // Método para atualizar um sorteio existente
        void Delete(int id); // Método para deletar um sorteio
        List<int> ObterNumerosSorteados(); // Obtém a lista de números sorteados
    }
}
