using LojaWeb.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class ProdutosDAO
    {
        private ISession session;

        public ProdutosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Produto produto)
        {
            
            session.Save(produto);
            

        }

        public void Remove(Produto produto)
        {
            
            session.Delete(produto);
            

        }

        public void Atualiza(Produto produto)
        {
            
            session.Merge(produto);
            
        }

        public Produto BuscaPorId(int id)
        {
            return session.Get<Produto>(id);
        }

        public IList<Produto> Lista()
        {
            string hql = "select p from Produto p";
            IQuery busca = session.CreateQuery(hql);

            return busca.List<Produto>();
        }

        public IList<Produto> ProdutosComPrecoMaiorDoQue(double? preco)
        {
            string hql = "from Produto p where p.Preco > :prec";
            IQuery busca = session.CreateQuery(hql);
            busca.SetParameter("prec", preco);
            
            return busca.List<Produto>();
        }

        public IList<Produto> ProdutosDaCategoria(string nomeCategoria)
        {
            string hql = "select p from Produto p join p.Categoria c where c.Nome like :categor";

            IQuery busca = session.CreateQuery(hql);
            busca.SetParameter("categor", "%"+nomeCategoria+"%");
            return busca.List<Produto>();
        }

        public IList<Produto> ProdutosDaCategoriaComPrecoMaiorDoQue(double? preco, string nomeCategoria)
        {
            string hql = "select p from Produto p join p.Categoria c where p.Preco > :prec and c.Nome =:categor";
            IQuery busca = session.CreateQuery(hql);
            busca.SetParameter("categor", nomeCategoria);
            busca.SetParameter("prec", preco.GetValueOrDefault(0.0));
           

            return busca.List<Produto>();
        }

        public IList<Produto> ListaPaginada(int paginaAtual)
        {
            string hql = "select p from Produto p order by p.Id";
            int resultadosPorPagina = 10;
            IQuery busca = session.CreateQuery(hql);
            busca.SetMaxResults(resultadosPorPagina);
            busca.SetFirstResult(resultadosPorPagina * (paginaAtual - 1));
            return busca.List<Produto>();
        }

        public IList<Produto> BuscaPorPrecoCategoriaENome(double? preco, string nomeCategoria, string nome)
        {
            ICriteria busca = session.CreateCriteria<Produto>();

            if(!string.IsNullOrEmpty(nome)){
                busca.Add(Restrictions.Eq("Nome", nome));
            
            }

            if (preco > 0)
            {
                busca.Add(Restrictions.Eq("Preco", preco));

            }

            if (!string.IsNullOrEmpty(nomeCategoria))
            {
                ICriteria buscaCategoria = busca.CreateCriteria("Categoria");
                buscaCategoria.Add(Restrictions.Eq("Nome", nomeCategoria));

            }


            return busca.List<Produto>();
        }
    }
}