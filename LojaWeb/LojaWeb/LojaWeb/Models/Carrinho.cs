using LojaWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaWeb.Models
{
    public class Carrinho
    {
        public IList<Produto> Produtos { get; set; }

        public Carrinho()
        {
            this.Produtos = new List<Produto>();
        }
        public void Adiciona(Entidades.Produto produto)
        {
            this.Produtos.Add(produto);    
        }

        public Venda CriaVenda(Usuario usuario)
        {
            return new Venda()
            {
                Produtos = this.Produtos,
                Cliente = usuario
            };
        }
    }
}
