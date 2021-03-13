using AppCardapio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCardapio.Data
{
    public class AppCardapioDbContext : DbContext
    {
        public AppCardapioDbContext (DbContextOptions<AppCardapioDbContext> options) : base(options)
        {

        }

        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<EndCidadeModel> EndCidade { get; set; }
        public DbSet<CepCidadeModel> CepCidade { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<RestauranteModel> Restaurante { get; set; }
        public DbSet<PedidoModel> Pedido { get; set; }



    }
}
