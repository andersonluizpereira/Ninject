using LojaWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Models
{
    public class ProdutosPorCategoria
    {
        public Categoria Categoria { get; set; }

        public long NumeroDeProdutos { get; set; }
    }
}