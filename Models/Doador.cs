using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColheitaSolidaria.Models
{
   

    public class DoadorModel
    {
        [Key]
        public int CodDoador { get; set; } //vem de perfil
    }

}
