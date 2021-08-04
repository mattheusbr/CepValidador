using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

    }
}