using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PraticaEntiryFramework.Model.ManyToMany
{
    public class Carrinho
    {
        [Key]
        public int Carrinho_Id { get; set; }
        public DateTime Data_Compra { get; set; }
        public List<CarrinhoProduto> CarrinhoProdutos { get; set; }
    }
}
