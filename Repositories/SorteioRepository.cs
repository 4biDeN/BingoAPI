using BingoAPI.DTOs;
using System.Collections.Generic;
using System.Linq;
using BingoAPI.Database;
using BingoAPI.Database.Models;

namespace BingoAPI.Repositories
{
    // Repositório que implementa operações de acesso a dados para sorteios
    public class SorteioRepository : ISorteioRepository
    {
        // Contexto do banco de dados, injetado via construtor
        private readonly BingoDbContext _context;

        // Construtor que recebe o contexto do banco de dados
        public SorteioRepository(BingoDbContext context)
        {
            _context = context;
        }

        // Obtém todos os sorteios do banco de dados
        public IEnumerable<SorteioDto> GetAll()
        {
            return _context.Sorteios
                .Select(s => new SorteioDto
                {
                    Id = s.Id,
                    NumeroSorteado = s.NumeroSorteado
                })
                .ToList();
        }

        // Obtém um sorteio específico pelo ID
        public SorteioDto GetById(int id)
        {
            var sorteio = _context.Sorteios.Find(id);
            if (sorteio != null)
            {
                return new SorteioDto
                {
                    Id = sorteio.Id,
                    NumeroSorteado = sorteio.NumeroSorteado
                };
            }
            return null;
        }

        // Adiciona um novo sorteio ao banco de dados
        public void Add(SorteioDto sorteioDto)
        {
            var random = new Random();
            var sorteio = new SorteioModel
            {
                NumeroSorteado = random.Next(1, 81) // Gera um número aleatório entre 1 e 80
            };

            _context.Sorteios.Add(sorteio);
            _context.SaveChanges();

            // Atualiza o DTO com o ID e número sorteado gerados
            sorteioDto.Id = sorteio.Id;
            sorteioDto.NumeroSorteado = sorteio.NumeroSorteado;
        }

        // Atualiza um sorteio existente no banco de dados
        public void Update(SorteioDto sorteioDto)
        {
            var sorteio = _context.Sorteios.Find(sorteioDto.Id);
            if (sorteio != null)
            {
                sorteio.NumeroSorteado = sorteioDto.NumeroSorteado;
                _context.SaveChanges();
            }
        }

        // Remove um sorteio do banco de dados pelo ID
        public void Delete(int id)
        {
            var sorteio = _context.Sorteios.Find(id);
            if (sorteio != null)
            {
                _context.Sorteios.Remove(sorteio);
                _context.SaveChanges();
            }
        }

        // Retorna uma lista de números sorteados a partir do banco de dados
        public List<int> ObterNumerosSorteados()
        {
            return _context.Sorteios
                .Select(s => s.NumeroSorteado)
                .ToList();
        }
    }
}
