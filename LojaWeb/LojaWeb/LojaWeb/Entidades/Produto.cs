using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Entidades
{
    public class Produto
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual double Preco { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}