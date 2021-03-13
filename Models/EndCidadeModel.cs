using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCardapio.Models
{
    public class EndCidadeModel
    {
        [Key]
        public int Id_cidade { get; set; }
        [MaxLength(40)]
        public string Nome_Cidade { get; set; }
        [ForeignKey("CepCidade")]
        public int Cep_Id { get; set; }
        public CepCidadeModel CepCidade { get; set; }
        public List<PessoaModel> Pessoa { get; set; }
    }
}
