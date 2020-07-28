using Microsoft.EntityFrameworkCore;
using PraticaEntiryFramework.Model.ManyToMany;
using System;
using System.Collections.Generic;
using System.Text;

namespace PraticaEntiryFramework.Context
{
    public class CarrinhoComprasContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<CarrinhoProduto> CarrinhoProduto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=DBECommerce;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarrinhoProduto>()
                        .HasKey(t => new { t.Carrinho_Id, t.Produto_Id });

            modelBuilder.Entity<CarrinhoProduto>()
                .HasOne(cp => cp.Carrinho)
                .WithMany(c => c.CarrinhoProdutos)
                .HasForeignKey(cp => cp.Carrinho_Id);

            modelBuilder.Entity<CarrinhoProduto>()
                .HasOne(cp => cp.Produto)
                .WithMany(p => p.CarrinhoProdutos)
                .HasForeignKey(cp => cp.Produto_Id);
        }
    }
}
