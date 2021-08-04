using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidadorCep.Business;
using ValidadorCep.DAO;
using ValidadorCep.Models;

namespace ValidadorCep.Controllers
{
    public class GothamController : Controller
    {
        GothamCepDao gothamCepDao = new GothamCepDao();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Endereco endereco)
        {
            var val = new Valida();
            if (!val.IsValidCep(endereco.CEP))
                ModelState.AddModelError("CEP", "CEP inválido");

            if (ModelState.IsValid)
            {

                gothamCepDao.Adicionar(endereco);
                return RedirectToAction("Index");
            }

            return View(endereco);
        }
    }
}