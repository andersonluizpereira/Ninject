using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Entidades
{
    public class Categoria
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual IList<Produto> Produtos { get; set; }
    
    
    }
}