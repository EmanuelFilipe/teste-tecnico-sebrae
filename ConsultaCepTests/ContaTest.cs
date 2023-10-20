using ConsultaCep.DataAccess.Data;
using ConsultaCep.DataAccess.Handler;
using ConsultaCep.DataAccess.Repository;
using ConsultaCep.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsultaCepTests
{
    public class ContaTest
    {
        private DbContextOptions _options;
        private ApplicationDbContext _context;
        private ContaRepository _contaRepository;
        private ContaHandler _contaHandler;

        public ContaTest()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase("DbCEPContext")
                            .Options;

            _context = new ApplicationDbContext(_options);
            _contaRepository = new ContaRepository(_context);
            _contaHandler = new ContaHandler(_contaRepository);
        }

        [Fact]
        public void TesteDeveCriarUmaConta()
        {
            // Arrange
            var comando = new Conta("Camiseta", "Camiseta Regata masculino");
            _contaHandler.Add(comando);

            // Act
            var conta = _contaRepository.FindById(comando.Id); 

            // Assert
            Assert.NotNull(conta);
        }

        [Fact]
        public void TesteDeveObterUmaContaPorId()
        {
            // Arrange
            var comando = new Conta("Camiseta", "Camiseta Regata masculino");
            _contaHandler.Add(comando);

            // Act
            var conta = _contaRepository.FindById(1);

            // Assert
            Assert.NotNull(conta);
            Assert.True(conta.Id == 1);
        }



        [Fact]
        public void TesteDeveEditarNomeDaConta()
        {
            // Arrange
            var comando = new Conta("Camiseta", "Camiseta Regata masculino");
            _contaHandler.Add(comando);

            // Act
            var conta = _contaRepository.FindById(1);
            conta.Nome = "Caneca";

            _contaHandler.Update(conta);

            var novaConsulta = _contaRepository.FindById(1);

            // Assert
            Assert.NotNull(novaConsulta);
            Assert.Equal("Caneca", novaConsulta.Nome);
        }

        [Fact]
        public void TesteDeveExcluirUmaContaExistente()
        {
            // Arrange
            var comando = new Conta("Camiseta", "Camiseta Regata masculino");
            _contaHandler.Add(comando);

            // Act
            _contaHandler.Delete(comando.Id);
            var itemExcluido = _contaRepository.FindById(comando.Id);

            // Assert
            Assert.Null(itemExcluido);
        }

    }
}