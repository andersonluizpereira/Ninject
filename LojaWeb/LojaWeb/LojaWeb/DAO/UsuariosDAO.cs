using LojaWeb.Entidades;
using LojaWeb.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class UsuariosDAO
    {
        private ISession session;

        public UsuariosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Usuario usuario)
        {
           
           session.Save(usuario);
           

        }

        public void Remove(Usuario usuario)
        {
           
           session.Delete(usuario);
           
        }

        public void Atualiza(Usuario usuario)
        {
           
            this.session.Merge(usuario);
           
        }

        public Usuario BuscaPorId(int id)
        {
            //
            return session.Get<Usuario>(id);
        }

        public IList<Usuario> Lista()
        {

            string hql = "select u from Usuario u";
            IQuery busca = session.CreateQuery(hql);

            return busca.List<Usuario>();
            //return new List<Usuario>();
        }
    }
}