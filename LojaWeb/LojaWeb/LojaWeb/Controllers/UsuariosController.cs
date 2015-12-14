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
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/
        private UsuariosDAO dao;

        public UsuariosController(UsuariosDAO dao) {

            this.dao = dao;
        
        }


        public ActionResult Index()
        {
            IList<Usuario> usuarios = dao.Lista();
            
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            dao.Adiciona(usuario);
            
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            
            Usuario user = dao.BuscaPorId(id);
            dao.Remove(user);
            

            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Usuario usuario = dao.BuscaPorId(id);
             return View(usuario);
        }

        public ActionResult Atualiza(Usuario usuario)
        {
            dao.Atualiza(usuario);
            return RedirectToAction("Index");
        }

    }
}
