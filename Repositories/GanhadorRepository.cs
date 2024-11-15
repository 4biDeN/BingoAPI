using System.Collections.Generic;
using System.Linq;
using BingoAPI.Database;
using BingoAPI.DTOs;

namespace BingoAPI.Repositories
{
    // Implementação do repositório que lida com a lógica de verificação de ganhadores
    public class GanhadorRepository : IGanhadorRepository
    {
        // Dependência do contexto do banco de dados, injetada via construtor
        private readonly BingoDbContext _context;

        // Construtor que recebe o contexto do banco de dados, promovendo a injeção de dependência
        public GanhadorRepository(BingoDbContext context)
        {
            _context = context;
        }

        // Método que verifica se uma cartela é vencedora comparando com os números sorteados
        public bool VerificarGanhador(List<int> numerosSorteados, CartelaDto cartela)
        {
            // Usa LINQ para verificar se todos os números da cartela estão nos números sorteados
            return cartela.Números.All(numero => numerosSorteados.Contains(numero));
        }

        // Método que retorna uma lista de cartelas vencedoras
        public List<CartelaDto> ObterGanhadores(List<int> numerosSorteados, IEnumerable<CartelaDto> cartelas)
        {
            var ganhadores = new List<CartelaDto>();

            // Itera sobre cada cartela para verificar se é vencedora
            foreach (var cartela in cartelas)
            {
                // Reutiliza o método VerificarGanhador para determinar se a cartela é vencedora
                if (VerificarGanhador(numerosSorteados, cartela))
                {
                    // Adiciona a cartela à lista de ganhadores se for vencedora
                    ganhadores.Add(cartela);
                }
            }

            return ganhadores;
        }
    }
}
