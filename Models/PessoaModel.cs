using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCardapio.Models
{
    [Table("Pessoas")]
    public class PessoaModel
    {
        [Key]
        public int Id_pessoa { get; set; }
        [MaxLength(60)]
        public string Nome_Completo { get; set; }
        public string Endereco_Rua { get; set; }
        public int Endereco_Numero { get; set; }
        public string Endereco_Bairro { get; set; }
        [ForeignKey("Endcidade")]
        public int Cidade_Id { get; set; }
        public EndCidadeModel Endcidade { get; set; }
        [MaxLength(11)]
        public string Telefone1 { get; set; }
        [MaxLength(11)]
        public string? Telefone2 { get; set; }
        public List<PedidoModel> Pedido { get; set; }


    }
}
