using BingoAPI.Database;
using BingoAPI.Repositories;
using BingoAPI.Services;

namespace BingoAPI.Factories
{
    public class GanhadorFabricMethod
    {
        public static IGanhadorService CreateGanhadorService(BingoDbContext context)
        {
            return new GanhadorService(new GanhadorRepository(context));
        }
    }
}
