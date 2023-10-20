using ConsultaCep.Models;

namespace ConsultaCep.DataAccess.Repository
{
    public interface IContaRepostitory
    {
        IList<Conta> GetAll();
        Conta FindById(long id);
        Conta Create(Conta dto);
        Conta Update(Conta dto);
        bool Delete(long id);

    }
}
