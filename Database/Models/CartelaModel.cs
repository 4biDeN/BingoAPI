using System;
using System.Collections.Generic;

namespace BingoAPI.Models
{
    public class CartelaModel
    {
        public int Id { get; set; }
        public List<int> Números { get; set; } // Lista de números
        public string NomeJogador { get; set; } // Nome do jogador

        public CartelaModel()
        {
            Números = GerarNumerosAleatorios();
        }

        private List<int> GerarNumerosAleatorios()
        {
            var numeros = new HashSet<int>();
            Random random = new Random();

            while (numeros.Count < 15)
            {
                numeros.Add(random.Next(1, 76)); // Números de 1 a 75
            }

            return new List<int>(numeros);
        }
    }
}
