using AutoMapper;
using ConsultaCep.DataAccess.Data;
using ConsultaCep.DataAccess.Data.DTO;
using ConsultaCep.DataAccess.Handler;
using ConsultaCep.DataAccess.Repository;
using ConsultaCep.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultaCepTests
{
    public class ContaTest
    {
        public DbContextOptions options;
        public ApplicationDbContext context;
        public ContaRepository contaRepository;
        private ContaHandler _contaHandler;

        public ContaTest()
        {

            var services = new ServiceCollection();

            // Configure o AutoMapper
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ContaDTO, Conta>();
                config.CreateMap<Conta, ContaDTO>();
            });

            IMapper mapper = mappingConfig.CreateMapper();

            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase("DbCEPContext")
                            .Options;

            context = new ApplicationDbContext(options);
            contaRepository = new ContaRepository(context, mapper);
            _contaHandler = new ContaHandler(contaRepository);
        }

        [Fact]
        public void TesteCriandoContaEObtendoAContaCriada()
        {
            var comando = new ContaDTO("Camiseta", "Camiseta Regata masculino");

            _contaHandler.Add(comando);

            var contas = contaRepository.GetAll();
            Assert.NotNull(contas);
            Assert.True(contas.Count() == 1);

        }

        [Fact]
        public void TesteObtendoContaPorId()
        {
            var comando = new ContaDTO("Camiseta", "Camiseta Regata masculino");

            _contaHandler.Add(comando);

            var conta = contaRepository.FindById(1).Result;
            Assert.NotNull(conta);
            Assert.True(conta.Id == 1);
        }



        [Fact]
        public async Task TesteEditandoConta2()
        {
            var comando = new ContaDTO("Camiseta", "Camiseta Regata masculino");
            _contaHandler.Add(comando);

            var conta = await contaRepository.FindById(1);
            conta.Nome = "Caneca";

            await _contaHandler.Update(conta);

            var novaConsulta = await contaRepository.FindById(1);

            Assert.NotNull(novaConsulta);
            Assert.Equal("Caneca", novaConsulta.Nome);

            //context.Contas.Add(new Conta("Camiseta", "Camiseta Regata masculino"));
            //context.SaveChanges();

            //var controller = new ContaController(contaRepository);

            //var okResult = controller.GetAll();
            //var valueResult = ((ObjectResult)okResult.Result).Value;
            //var items = Assert.IsType<List<ContaDTO>>(valueResult);

            //Assert.Equal(200, ((ObjectResult)okResult.Result).StatusCode);
            //Assert.NotNull(items);
            //Assert.True(items.Count > 0);
        }

        [Fact]
        public void TesteExcluindoConta()
        {
            var comando = new ContaDTO("Camiseta", "Camiseta Regata masculino");
            _contaHandler.Add(comando);

            var conta = contaRepository.FindById(1).Result;

            _contaHandler.Delete((int)conta.Id);

            var novaConsulta = contaRepository.GetAll();

            Assert.True(novaConsulta.Count() == 0);            
        }





    }
}