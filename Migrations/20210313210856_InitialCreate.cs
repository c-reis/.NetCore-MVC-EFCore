using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AppCardapio.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CepCidades",
                columns: table => new
                {
                    Id_cep = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero_Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CepCidades", x => x.Id_cep);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    Id_restaurante = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_restaurante = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Cnpj = table.Column<string>(type: "text", nullable: true),
                    Telefone1 = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    Telefone2 = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.Id_restaurante);
                });

            migrationBuilder.CreateTable(
                name: "EndCidade",
                columns: table => new
                {
                    Id_cidade = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_Cidade = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Cep_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndCidade", x => x.Id_cidade);
                    table.ForeignKey(
                        name: "FK_EndCidade_CepCidades_Cep_Id",
                        column: x => x.Cep_Id,
                        principalTable: "CepCidades",
                        principalColumn: "Id_cep",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id_produto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_Produto = table.Column<string>(type: "text", nullable: true),
                    Valor_Produto = table.Column<double>(type: "double precision", nullable: false),
                    Descricao_Produto = table.Column<string>(type: "text", nullable: true),
                    Restaurante_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id_produto);
                    table.ForeignKey(
                        name: "FK_Produtos_Restaurantes_Restaurante_Id",
                        column: x => x.Restaurante_Id,
                        principalTable: "Restaurantes",
                        principalColumn: "Id_restaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id_pessoa = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_Completo = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Endereco_Rua = table.Column<string>(type: "text", nullable: true),
                    Endereco_Numero = table.Column<int>(type: "integer", nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "text", nullable: true),
                    Cidade_Id = table.Column<int>(type: "integer", nullable: false),
                    Telefone1 = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    Telefone2 = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id_pessoa);
                    table.ForeignKey(
                        name: "FK_Pessoas_EndCidade_Cidade_Id",
                        column: x => x.Cidade_Id,
                        principalTable: "EndCidade",
                        principalColumn: "Id_cidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id_Pedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data_Hora = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Pessoa_Id = table.Column<int>(type: "integer", nullable: false),
                    Restaurante_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id_Pedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Pessoas_Pessoa_Id",
                        column: x => x.Pessoa_Id,
                        principalTable: "Pessoas",
                        principalColumn: "Id_pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Restaurantes_Restaurante_Id",
                        column: x => x.Restaurante_Id,
                        principalTable: "Restaurantes",
                        principalColumn: "Id_restaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoModelProdutoModel",
                columns: table => new
                {
                    PedidoId_Pedido = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId_produto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoModelProdutoModel", x => new { x.PedidoId_Pedido, x.ProdutoId_produto });
                    table.ForeignKey(
                        name: "FK_PedidoModelProdutoModel_Pedidos_PedidoId_Pedido",
                        column: x => x.PedidoId_Pedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id_Pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoModelProdutoModel_Produtos_ProdutoId_produto",
                        column: x => x.ProdutoId_produto,
                        principalTable: "Produtos",
                        principalColumn: "Id_produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EndCidade_Cep_Id",
                table: "EndCidade",
                column: "Cep_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoModelProdutoModel_ProdutoId_produto",
                table: "PedidoModelProdutoModel",
                column: "ProdutoId_produto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Pessoa_Id",
                table: "Pedidos",
                column: "Pessoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Restaurante_Id",
                table: "Pedidos",
                column: "Restaurante_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Cidade_Id",
                table: "Pessoas",
                column: "Cidade_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Restaurante_Id",
                table: "Produtos",
                column: "Restaurante_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoModelProdutoModel");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "EndCidade");

            migrationBuilder.DropTable(
                name: "CepCidades");
        }
    }
}
