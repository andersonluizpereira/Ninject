using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }
    }
}