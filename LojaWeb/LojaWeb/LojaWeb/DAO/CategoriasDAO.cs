using LojaWeb.Entidades;
using LojaWeb.Models;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class CategoriasDAO
    {
        private ISession session;

        public CategoriasDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Categoria categoria)
        {
           
            session.Save(categoria);
           
        }

        public void Remove(Categoria categoria)
        {
           
            session.Delete(categoria);
           


        }

        public void Atualiza(Categoria categoria)
        {
           
            session.Merge(categoria);
           
        }

        public Categoria BuscaPorId(int id)
        {
            return session.Get<Categoria>(id);
        }

        public IList<Categoria> Lista()
        {
            string hql = " select c from Categoria c";

           // string hql = "select distinct c from Categoria c join fetch c.Produtos";
            IQuery busca = session.CreateQuery(hql);
            return busca.List<Categoria>();
        }

        public IList<Categoria> BuscaPorNome(string nome)
        {
            string hql = "select c from Categoria c where c.Nome like:nomeb";
            IQuery busca = session.CreateQuery(hql);

            busca.SetParameter("nomeb", "%"+nome+"%");

            return busca.List<Categoria>();
        }

        public IList<ProdutosPorCategoria> ListaNumeroDeProdutosPorCategoria()
        {
            String hql = "select p.Categoria as Categoria, count(p) as NumeroDeProdutos from Produto p group by p.Categoria.Id,p.Categoria.Nome";
            IQuery busca = session.CreateQuery(hql);
  busca.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());
  IList<ProdutosPorCategoria> relatorio = busca.List<ProdutosPorCategoria>();
            return busca.List<ProdutosPorCategoria>();
        }

       // public IList<Categoria> BuscaPorNome(string nomecategoria) {
            
          

        
        //}
    
    
    }

}