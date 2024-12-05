using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ColheitaSolidaria.Models
{
    public class AprovacaoModel
    {
        [Key] // tipo chave
        public int CodDoacao { get; set; }
        [ForeignKey("AdministradorModel")]
        public int CodAdm { get; set; }
        public DateTime DataAprovacao { get; set; }

    }
}
