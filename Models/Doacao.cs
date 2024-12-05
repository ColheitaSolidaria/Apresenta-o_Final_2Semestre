using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ColheitaSolidaria.Models
{
   

    public class DoacaoModel
    {
        internal int RecebedorModel;

        [Key] // tipo chave
        public int CodDoacao { get; set; }

        // tipo chave
        [ForeignKey("RecebedorModel")]
        public int CodRecebedor { get; set; }

        // tipo chave
        [ForeignKey("DoadorModel")]
        public int CodDoador { get; set; }

        [MaxLength(50)]
        public required string Tipo { get; set; }

        public required DateTime DataValidade { get; set; }

        [MaxLength(100)]
        public required string Descricao { get; set; }

    }
}
