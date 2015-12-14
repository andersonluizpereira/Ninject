using log4net;
using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        //
        // GET: /Produtos/

        private ProdutosDAO dao;
        private CategoriasDAO dal;

        public ProdutosController(ProdutosDAO dao, CategoriasDAO dal) {
            this.dao = dao;
            this.dal = dal;
        }


        public ActionResult Index()
        {
           
            IList<Produto> produtos = dao.Lista();
         
            return View(produtos);
        }

        public ActionResult Form()
        {

            //CategoriaDao dao = new CategoriaDao();

            //ViewBag.Produto = new Produto { Categoria = new CategoriaDoProduto() };


           IList<Categoria> categorias = dal.Lista();
            
            
            return View(categorias);


           // return View();

        }

        public ActionResult Adiciona(Produto produto)
        {

            if (produto.Categoria.Id == 0) {

                produto.Categoria = null;

            }
           
            dao.Adiciona(produto);
           
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {

            Produto prod = dao.BuscaPorId(id);
            dao.Remove(prod);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            
            Produto produto =  dao.BuscaPorId(id);
            //Produto p = new Produto();
            
            return View(produto);
        }

        public ActionResult Atualiza(Produto produto)
        {
             dao.Atualiza(produto);
            return RedirectToAction("Index");
        }

        public ActionResult ProdutosComPrecoMinimo(double? preco)
        {
            ViewBag.Preco = preco;
            IList<Produto> produtos = dao.ProdutosComPrecoMaiorDoQue(preco);
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoria(string nomeCategoria)
        {
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = dao.ProdutosDaCategoria(nomeCategoria);
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoriaComPrecoMinimo(double? preco, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = dao.ProdutosDaCategoriaComPrecoMaiorDoQue(preco,nomeCategoria);
            return View(produtos);
        }

        public ActionResult BuscaDinamica(double? preco, string nome, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.Nome = nome;
            ViewBag.NomeCategoria = nomeCategoria;

            IList<Produto> produtos = dao.BuscaPorPrecoCategoriaENome(preco,nomeCategoria,nome);
            return View(produtos);
        }
        public ActionResult ListaPaginada(int? pagina)
        {
            int paginaAtual = pagina.GetValueOrDefault(1);
            ViewBag.Pagina = paginaAtual;
            IList<Produto> produtos = dao.ListaPaginada(paginaAtual);
            return View(produtos);
        }
    }
}
