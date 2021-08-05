using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ValidadorCep.Models;
using static ValidadorCep.Models.Usuario;

namespace ValidadorCep.Filter
{
    public class AutenticacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = filterContext.HttpContext.Session["usuarioLogado"];
            if (!(usuario != null && usuario is Usuario))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Login",
                            action = "Autentica"
                        }));
            }
        }   
    }
}