using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loja_Info.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() // VIEW DA HOME
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null) //SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else //RECARREGARÁ A PÁGINA
            {
                return View();
            }
        }
    }
}