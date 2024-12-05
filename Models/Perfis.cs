using System.ComponentModel.DataAnnotations;

namespace ColheitaSolidaria.Models
{

    public class Perfil
    {

            [Key] // tipo chave
            public int Cod { get; set; }

            public required string Nome { get; set; }

            public required string Sobrenome { get; set; }

            [MaxLength(11)]
            public required string CPF { get; set; }
            [MaxLength(11)]

            public required DateTime DataNasc { get; set; }

            [MaxLength(100)]
            public required string Email { get; set; }

            [MaxLength(15)]
            public required string Telefone { get; set; }

            //[MaxLength(225)]
            //public required string Endereco { get; set; }


            [MaxLength(50)]
            public required string Senha { get; set; }

        internal static void Clear()
        {
            throw new NotImplementedException();
        }
    }
    }
