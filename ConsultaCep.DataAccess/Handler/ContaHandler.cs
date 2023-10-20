using ConsultaCep.DataAccess.Repository;
using ConsultaCep.Models;

namespace ConsultaCep.DataAccess.Handler
{
    public class ContaHandler
    {
        IContaRepostitory _contaRepostitory;

        public ContaHandler(IContaRepostitory contaRepostitory)
        {
            _contaRepostitory = contaRepostitory;
        }

        public void Add(Conta model)
        {
           _contaRepostitory.Create(model);
        }

        public void Update(Conta dto)
        {
            _contaRepostitory.Update(dto);
        }

        public void Delete(long id)
        {
            _contaRepostitory.Delete(id);
        }

    }
}
