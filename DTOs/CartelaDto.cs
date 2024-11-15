using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BingoAPI.DTOs
{
    public class CartelaDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public List<int> Números { get; set; } // Lista de números
        public string NomeJogador { get; set; } // Nome do jogador
    }
}
