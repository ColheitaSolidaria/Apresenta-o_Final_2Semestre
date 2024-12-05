using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ColheitaSolidaria.Models
{
    
    public class AdministradorModel
    {
        [Key] // tipo chave
        public int CodAdm { get; set; }

        [MaxLength(14)]
        public required string CNPJ { get; set; }

        [MaxLength(50)]
        public required string Senha { get; set; }

    }

}
