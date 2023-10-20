using ConsultaCep.DataAccess.Data.DTO;
using ConsultaCep.DataAccess.Repository;
using ConsultaCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsultaCep.DataAccess.Handler
{
    public class ContaHandler
    {
        IContaRepostitory _contaRepostitory;

        public ContaHandler(IContaRepostitory contaRepostitory)
        {
            _contaRepostitory = contaRepostitory;
        }

        public void Add(ContaDTO model)
        {
            _contaRepostitory.Create(model);
        }

        public async Task Update(ContaDTO dto)
        {
            await _contaRepostitory.Update(dto);
        }

        public void Delete(int id)
        {
            _contaRepostitory.Delete(id);
        }

    }
}
