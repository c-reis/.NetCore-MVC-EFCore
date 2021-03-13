using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppCardapio.Models
{
    [Table("Restaurantes")]
    public class RestauranteModel
    {
        [Key]
        public int Id_restaurante { get; set; }
        [MaxLength(40)]
        public string Nome_restaurante { get; set; }
        public string Cnpj { get; set; }
        [MaxLength(11)]
        public string Telefone1 { get; set; }
        [MaxLength(11)]
        public string? Telefone2 { get; set; }
        public List<ProdutoModel> Produto { get; set; }
    }
}
