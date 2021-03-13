using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCardapio.Models
{
    [Table("Pedidos")]
    public class PedidoModel
    {
        [Key]
        public int Id_Pedido { get; set; }
        public DateTime Data_Hora { get; set; }
        [ForeignKey("Pessoa")]
        public int Pessoa_Id { get; set; }
        public PessoaModel Pessoa { get; set; }
        [ForeignKey("Restaurante")]
        public int Restaurante_Id { get; set; }
        public RestauranteModel Restaurante { get; set; }
        public List<ProdutoModel> Produto { get; set; }

    }
}
