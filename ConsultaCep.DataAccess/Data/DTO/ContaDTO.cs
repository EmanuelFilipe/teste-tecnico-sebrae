using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCep.DataAccess.Data.DTO
{
    public class ContaDTO
    {
        public ContaDTO(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
