using BingoAPI.Database;
using BingoAPI.Repositories;
using BingoAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BingoAPI.Factories
{
    // Fábrica para criar instâncias de serviços de cartelas
    public class CartelasFactoryMethod
    {
        // Método para criar um novo serviço de cartela
        public static ICartelaService CreateCartelaService(BingoDbContext context)
        {
            // Cria uma instância de CartelaService usando CartelaRepository
            return new CartelaService(new CartelaRepository(context));
        }
    }
}
