using BingoAPI.Models;
using BingoAPI.DTOs;
using System.Collections.Generic;

namespace BingoAPI.Repositories
{
    // Interface que define operações de repositório para cartelas
    public interface ICartelaRepository
    {
        IEnumerable<CartelaDto> GetAll(); // Obtém todas as cartelas como DTOs
        CartelaDto GetById(int id); // Obtém uma cartela específica como DTO
        void Add(CartelaDto cartelaDto); // Adiciona uma nova cartela
        void Update(CartelaDto cartelaDto); // Atualiza uma cartela existente
        void Delete(int id); // Deleta uma cartela pelo ID
    }
}
