using BingoAPI.DTOs;
using BingoAPI.Repositories;
using System.Collections.Generic;

namespace BingoAPI.Services
{
    // Serviço que gerencia as operações relacionadas às cartelas de bingo
    public class CartelaService : ICartelaService
    {
        // Dependência do repositório de cartelas, injetada via construtor
        private readonly ICartelaRepository _repository;

        // Construtor que recebe o repositório, promovendo a injeção de dependência
        public CartelaService(ICartelaRepository repository)
        {
            _repository = repository;
        }

        // Obtém todas as cartelas existentes, retornando uma coleção de DTOs
        public IEnumerable<CartelaDto> GetAllCartelas()
        {
            return _repository.GetAll();
        }

        // Obtém uma cartela específica pelo ID, retornando um DTO
        public CartelaDto GetCartelaById(int id)
        {
            return _repository.GetById(id);
        }

        // Cria uma nova cartela a partir de um DTO
        public void CreateCartela(CartelaDto cartela)
        {
            _repository.Add(cartela);
        }

        // Atualiza uma cartela existente usando dados de um DTO
        public void UpdateCartela(CartelaDto cartela)
        {
            _repository.Update(cartela);
        }

        // Deleta uma cartela pelo ID
        public void DeleteCartela(int id)
        {
            _repository.Delete(id);
        }
    }
}
