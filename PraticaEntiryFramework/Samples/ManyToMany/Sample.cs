using PraticaEntiryFramework.Context;
using PraticaEntiryFramework.Model.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PraticaEntiryFramework.Samples.ManyToMany
{
    public class Sample
    {
        public static void Run()
        {
            Console.WriteLine("Exemplo de carrinho de compras. Relacionamento Many-to-Many.");

            using (var dBContext = new CarrinhoComprasContext())
            {
                Produto produto = new Produto
                {
                    Nome = "NVidia GForce 6800",
                    Preco = new Decimal(79.99),
                    Quantidade = 20
                };
                Console.WriteLine("Criando produto: ", produto.ToString());
                dBContext.Produto.Add(produto);

                produto = new Produto
                {
                    Nome = "SSD 240GB WD Green",
                    Preco = new Decimal(299.99),
                    Quantidade = 10
                };
                Console.WriteLine("Criando produto: ", produto.ToString());
                dBContext.Produto.Add(produto);

                produto = new Produto
                {
                    Nome = "Notebook Lenovo Ideapad i5 1TB 16GB",
                    Preco = new Decimal(2999.99),
                    Quantidade = 10
                };
                Console.WriteLine("Criando produto: ", produto.ToString());
                dBContext.Produto.Add(produto);

                dBContext.Produto.Add(produto);

                Carrinho carrinho = new Carrinho
                {
                    Data_Compra = new DateTime(2020, 07, 20)
                };

                Console.WriteLine("Criando carrinho de compras: ", carrinho.ToString());
                dBContext.Carrinho.Add(carrinho);

                var carrinhoBase = dBContext.Carrinho.First();
                var produtoBase = dBContext.Produto.First();
                CarrinhoProduto carrinhoProduto = new CarrinhoProduto
                {
                    Carrinho_Id = carrinhoBase.Carrinho_Id,
                    Produto_Id = produtoBase.Produto_Id,
                    Quantidade = 2,
                    Preco_Total = new Decimal(220.00)
                };
                dBContext.Add(carrinhoProduto);
                Console.WriteLine("Associando um carrinho de compras a um produto.");

                Console.WriteLine("Salvando alterações...");
                dBContext.SaveChanges();
                Console.WriteLine("Cadastro realizado com sucesso!");
            }

            Console.WriteLine("Demonstração Many-to-one concluída.");
            Console.ReadLine();
        }
    }
}
