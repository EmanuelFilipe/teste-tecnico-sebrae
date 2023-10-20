using ConsultaCep.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaCep.Models
{
    public class Conta : BaseEntity
    {
        public Conta(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        [Required]
        [Column("nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("descricao")]
        [StringLength(500)]
        public string Descricao { get; set; }
    }
}
