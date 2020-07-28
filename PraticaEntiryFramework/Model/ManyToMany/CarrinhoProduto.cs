using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PraticaEntiryFramework.Model.ManyToMany
{
    public class CarrinhoProduto
    {
        public int Carrinho_Id { get; set; }
        public Carrinho Carrinho { get; set; }
        public int Produto_Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public Decimal Preco_Total { get; set; }
    }
}