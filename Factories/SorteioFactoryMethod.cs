using BingoAPI.Database;
using BingoAPI.Repositories;
using BingoAPI.Services;

namespace BingoAPI.Factories
{
    // Fábrica para criar instâncias de serviços de sorteio
    public static class SorteioFactoryMethod
    {
        // Método para criar um novo serviço de sorteio
        public static ISorteioService CreateSorteioService(BingoDbContext context)
        {
            // Cria uma instância de SorteioService usando SorteioRepository
            return new SorteioService(new SorteioRepository(context));
        }
    }
}
