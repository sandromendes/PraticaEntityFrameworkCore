using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PraticaEntiryFramework.Model.ManyToMany
{
    public class Produto
    {
        [Key]
        public int Produto_Id { get; set; }
        public string Nome { get; set; }
        public Decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public List<CarrinhoProduto> CarrinhoProdutos { get; set; }
    }
}
