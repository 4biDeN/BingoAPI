using System;
using System.Collections.Generic;

namespace BingoAPI.Database.Models
{
    public class GanhadorModel
    {
        public int Id { get; set; } // ID do ganhador
        public string Nome { get; set; } // Nome do ganhador
        public List<int> CartelasVencedoras { get; set; } // IDs das cartelas vencedoras
        public DateTime DataVitoria { get; set; } // Data da vitória

        public GanhadorModel()
        {
            CartelasVencedoras = new List<int>();
        }
    }
}
