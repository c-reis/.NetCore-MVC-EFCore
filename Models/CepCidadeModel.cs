using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCardapio.Models
{
    [Table("CepCidades")]
    public class CepCidadeModel
    {
        [Key]
        public int Id_cep { get; set; }
        [MaxLength(8)]
        public string Numero_Cep { get; set; }
    }
}
