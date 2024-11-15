using Microsoft.EntityFrameworkCore;
using BingoAPI.Models;
using BingoAPI.Database.Models;

namespace BingoAPI.Database
{
    public class BingoDbContext : DbContext
    {
        public BingoDbContext(DbContextOptions<BingoDbContext> options) : base(options) { }

        public DbSet<CartelaModel> Cartelas { get; set; }
        public DbSet<SorteioModel> Sorteios { get; set; }
        public DbSet<GanhadorModel> Ganhadores { get; set; }
    }
}
