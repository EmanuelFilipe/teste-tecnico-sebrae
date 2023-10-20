using ConsultaCep.Web.Models;

namespace ConsultaCep.Web.Services.IServices
{
    public interface IContaService
    {
        Task<IEnumerable<ContaModel>> GetAll();
        Task<ContaModel> FindContaById(long id);
        Task<ContaModel> Create(ContaModel model);
        Task<ContaModel> Update(ContaModel model);
        Task<bool> Delete(long id);

    }
}
