using BingoAPI.DTOs;
using System.Collections.Generic;

namespace BingoAPI.Services
{
    // Interface que define as operações para o serviço de cartelas
    public interface ICartelaService
    {
        IEnumerable<CartelaDto> GetAllCartelas(); // Retorna todas as cartelas como DTOs
        CartelaDto GetCartelaById(int id); // Retorna uma cartela específica como DTO
        void CreateCartela(CartelaDto cartela); // Cria uma nova cartela a partir de um DTO
        void UpdateCartela(CartelaDto cartela); // Atualiza uma cartela existente
        void DeleteCartela(int id); // Deleta uma cartela pelo ID
    }
}
