using ConsultaCep.DataAccess.Repository;
using ConsultaCep.Web.Models;
using ConsultaCep.Web.Services.IServices;
using ConsultaCep.Web.Utils;

namespace ConsultaCep.Web.Services
{
    public class ContaService : IContaService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/conta";


        public ContaService(HttpClient client)
        {
            _httpClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ContaModel>> GetAll()
        {
            var response = await _httpClient.GetAsync(BasePath);
            var teste = await response.ReadContentAs<List<ContaModel>>();
            return await response.ReadContentAs<List<ContaModel>>();
        }

        public async Task<ContaModel> FindContaById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ContaModel>();
        }

        public async Task<ContaModel> Create(ContaModel model)
        {
            var response = await _httpClient.PostAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ContaModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<ContaModel> Update(ContaModel model)
        {
            var response = await _httpClient.PutAsJson(BasePath, model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ContaModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> Delete(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}
