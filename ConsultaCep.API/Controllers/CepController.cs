using ConsultaCep.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Swashbuckle.AspNetCore.Annotations;

namespace ConsultaCep.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly RestClient _client;

        public CepController()
        {
            _client = new RestClient("https://viacep.com.br/ws/");
        }

        [HttpGet("{cep}")]
        [SwaggerOperation(Summary = "Obter um endereço", Description = "Retorna um endereço com base no CEP fornecido.")]
        public async Task<ActionResult<Conta>> GetAdrress(string cep)
        {
            if (cep.Replace("-", "").Length < 8) return BadRequest("CEP Inválido");

            var adrress = await CallApiCorreios(cep);

            if (adrress == null) return NotFound("CEP não encontrado.");

            return Ok(adrress);
        }

        private async Task<Endereco?> CallApiCorreios(string cep)
        {
            var request = new RestRequest($"{cep}/json", (Method)DataFormat.Json);
            var response = await _client.GetAsync<Endereco>(request);

            return response;
        }
    }
}

