using ConsultaCep.DataAccess.Data.DTO;
using ConsultaCep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCep.DataAccess.Repository
{
    public interface IContaRepostitory
    {
        IEnumerable<ContaDTO> GetAll();
        Task<ContaDTO> FindById(long id);
        Task<ContaDTO> Create(ContaDTO dto);
        Task<ContaDTO> Update(ContaDTO dto);
        Task<bool> Delete(long id);

    }
}
