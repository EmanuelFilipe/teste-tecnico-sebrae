using ConsultaCep.DataAccess.Data.DTO;
using ConsultaCep.DataAccess.Repository;
using ConsultaCep.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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
        public async Task<ActionResult<ContaDTO>> GetAdrress(string cep)
        {
            if (cep.Replace("-", "").Length < 8) return BadRequest("CEP Inválido");

            var adrress = CallApiCorreios(cep);

            if (adrress == null) return NotFound("CEP não encontrado.");

            return Ok(adrress);
        }

        private Endereco? CallApiCorreios(string cep)
        {
            var request = new RestRequest($"{cep}/json", (Method)DataFormat.Json);
            var response = _client.Get<Endereco>(request);

            return response;
        }
    }
}

