using BingoAPI.Models;
using BingoAPI.DTOs;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BingoAPI.Database;

namespace BingoAPI.Repositories
{
    // Repositório que implementa operações de acesso a dados para cartelas
    public class CartelaRepository : ICartelaRepository
    {
        // Contexto do banco de dados, injetado via construtor
        private readonly BingoDbContext _context;

        // Construtor que recebe o contexto do banco de dados
        public CartelaRepository(BingoDbContext context)
        {
            _context = context;
        }

        // Obtém todas as cartelas do banco de dados, convertendo-as para DTOs
        public IEnumerable<CartelaDto> GetAll()
        {
            return _context.Cartelas
                .Select(c => new CartelaDto
                {
                    Id = c.Id,
                    NomeJogador = c.NomeJogador,
                    Números = c.Números
                })
                .ToList();
        }

        // Obtém uma cartela específica pelo ID, convertendo-a para um DTO
        public CartelaDto GetById(int id)
        {
            var cartela = _context.Cartelas
                .FirstOrDefault(c => c.Id == id);

            if (cartela == null) return null;

            return new CartelaDto
            {
                Id = cartela.Id,
                NomeJogador = cartela.NomeJogador,
                Números = cartela.Números
            };
        }

        // Adiciona uma nova cartela ao banco de dados, a partir de um DTO
        public void Add(CartelaDto cartelaDto)
        {
            var cartela = new CartelaModel
            {
                NomeJogador = cartelaDto.NomeJogador,
                Números = cartelaDto.Números
            };

            _context.Cartelas.Add(cartela);
            _context.SaveChanges();
        }

        // Atualiza uma cartela existente no banco de dados
        public void Update(CartelaDto cartelaDto)
        {
            var cartela = _context.Cartelas.Find(cartelaDto.Id);
            if (cartela != null)
            {
                cartela.NomeJogador = cartelaDto.NomeJogador;
                cartela.Números = cartelaDto.Números;
                _context.SaveChanges();
            }
        }

        // Remove uma cartela do banco de dados pelo ID
        public void Delete(int id)
        {
            var cartela = _context.Cartelas.Find(id);
            if (cartela != null)
            {
                _context.Cartelas.Remove(cartela);
                _context.SaveChanges();
            }
        }
    }
}
