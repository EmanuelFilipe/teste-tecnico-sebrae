using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultaCep.Web.Models
{
    public class ContaModel
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        //[StringLength(500)]
        [DisplayName("Descrição")]
        [MaxLength(50)]
        public string Descricao { get; set; }
    }
}
