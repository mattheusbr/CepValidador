using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ValidadorCep.Business;
using ValidadorCep.DAO;
using ValidadorCep.Filter;
using ValidadorCep.Models;

namespace ValidadorCep.Controllers
{
    public class GothamController : Controller
    {
        private GothamCepDao gothamCepDao = new GothamCepDao();
        private Valida val = new Valida();

        public ActionResult Index()
        {
            return View(gothamCepDao.BuscarTodosEnderecos());
        }

        [AutenticacaoFilterAttribute]
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AutenticacaoFilterAttribute]
        public ActionResult Adicionar(Endereco endereco)
        {
            if (!val.IsValidCep(endereco.CEP))
                ModelState.AddModelError("CEP", "CEP inválido");

            if (ModelState.IsValid)
            {
                gothamCepDao.Adicionar(endereco);
                return RedirectToAction("Index");
            }

            return View(endereco);
        }

        [AutenticacaoFilterAttribute]
        public ActionResult Editar(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var endereco = gothamCepDao.BuscarEnderecoPorId(id);
            if (endereco == null)            
                return HttpNotFound();
            
            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AutenticacaoFilterAttribute]
        public ActionResult Editar(Endereco endereco)
        {
            if (!val.IsValidCep(endereco.CEP))
                ModelState.AddModelError("CEP", "CEP inválido");

            if (ModelState.IsValid)
            {
                gothamCepDao.Atualizar(endereco);
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AutenticacaoFilterAttribute]
        public ActionResult Deletar(int id)
        {
            gothamCepDao.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}