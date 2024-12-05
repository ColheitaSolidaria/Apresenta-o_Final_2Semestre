using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ColheitaSolidaria.Models
{
  
    public class RecebedorModel
    {
        [Key]
        public int CodRecebedor { get; set; } //vem de perfil

        public required int NFamiliar { get; set; }

    }

}
