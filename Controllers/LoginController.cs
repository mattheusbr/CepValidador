    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ValidadorCep.DAO;
using ValidadorCep.Models;

namespace ValidadorCep.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioDao usuarioDao = new UsuarioDao();

        public ActionResult Autentica()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autentica(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioEncontrado = usuarioDao.Buscar(usuario);
                if (usuarioEncontrado != null)
                {
                    Session["usuarioLogado"] = usuarioEncontrado;
                    return RedirectToAction("Index", "Gotham");
                }
                else
                {
                    return RedirectToAction("Autentica");
                }
            }
            return View(usuario);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Abandon();
            return RedirectToAction("Index", "Gotham");
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Usuario usuario)
        {
            if (usuarioDao.BuscarLoginExistente(usuario))            
                ModelState.AddModelError("Login", "Login existente.");
            

            if (ModelState.IsValid)
            {
                usuarioDao.Adiciona(usuario);
                return RedirectToAction("Autentica", "Login");
            }

            return View(usuario);
        }
    }
}