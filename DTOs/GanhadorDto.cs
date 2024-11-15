using System;
using System.Collections.Generic;

namespace BingoAPI.DTOs
{
    public class GanhadorDto
    {
        public int Id { get; set; } // ID do ganhador
        public string Nome { get; set; } // Nome do ganhador
        public List<int> CartelasVencedoras { get; set; } // IDs das cartelas vencedoras
        public DateTime DataVitoria { get; set; } // Data da vitória
    }
}
