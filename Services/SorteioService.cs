using BingoAPI.DTOs;
using BingoAPI.Repositories;
using System.Collections.Generic;

namespace BingoAPI.Services
{
    // Serviço para gerenciar operações de sorteio
    public class SorteioService : ISorteioService
    {
        // Dependência do repositório de sorteios, injetada via construtor
        private readonly ISorteioRepository _repository;

        // Construtor que recebe o repositório, permitindo a injeção de dependência
        public SorteioService(ISorteioRepository repository)
        {
            _repository = repository;
        }

        // Realiza um novo sorteio e o adiciona ao repositório
        public SorteioDto RealizarSorteio(SorteioDto sorteio)
        {
            _repository.Add(sorteio);
            return sorteio; // Retorna o sorteio adicionado
        }

        // Obtém todos os sorteios registrados
        public IEnumerable<SorteioDto> GetAllSorteios()
        {
            return _repository.GetAll();
        }

        // Obtém um sorteio específico pelo ID
        public SorteioDto GetSorteioById(int id)
        {
            return _repository.GetById(id);
        }

        // Atualiza um sorteio existente
        public void UpdateSorteio(SorteioDto sorteio)
        {
            _repository.Update(sorteio);
        }

        // Remove um sorteio pelo ID
        public void DeleteSorteio(int id)
        {
            _repository.Delete(id);
        }

        // Obtém uma lista de números que foram sorteados
        public List<int> ObterNumerosSorteados()
        {
            return _repository.ObterNumerosSorteados();
        }
    }
}
