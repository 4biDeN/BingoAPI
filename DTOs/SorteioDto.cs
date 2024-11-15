using System.Text.Json.Serialization;

namespace BingoAPI.DTOs
{
    public class SorteioDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int NumeroSorteado { get; set; }
    }
}
