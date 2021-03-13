using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCardapio.Models
{
    [Table("Produtos")]
    public class ProdutoModel
    {
        [Key]
        public int Id_produto { get; set; }
        public string Nome_Produto { get; set; }
        public double Valor_Produto { get; set; }
        public string Descricao_Produto { get; set; }
        [ForeignKey("Restaurante")]
        public int Restaurante_Id { get; set; }
        public RestauranteModel Restaurante { get; set; }
        public List<PedidoModel> Pedido { get; set; }
    }
}
