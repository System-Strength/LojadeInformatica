using loja_Info.Dados;
using loja_Info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace loja_Info.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        acoesLogin acoes = new acoesLogin();

        public ActionResult Login()
        {
            return View();
        }

        //criando o método http para verificar se o usuario e senha estão no banco
        [HttpPost]
        public ActionResult Login(modelFuncionario funcionario)
        {
            // metodo que testa o usuario no banco
            acoes.TestarUsuario(funcionario);

            if (funcionario.RgFunc != null && funcionario.SenhaFunc != null)
            {
                // criado um metodo de criptografia apra verificar um objeto(nome e senha) e depois criada a sessão para validação.
                FormsAuthentication.SetAuthCookie(funcionario.RgFunc, false);
                Session["usuarioLogado"] = funcionario.RgFunc.ToString();
                Session["senhaLogado"] = funcionario.SenhaFunc.ToString();


                //verifica se o tipo de usuário é gerente ou funcionario
                if (funcionario.TipoFunc == "0") // caso tipo 0 é gerente;
                {
                    Session["tipoLogado0"] = funcionario.TipoFunc.ToString(); //=1;
                    return RedirectToAction("cadFuncionario", "Funcionario");
                }
                else
                {
                    Session["tipoLogado1"] = funcionario.TipoFunc.ToString();//=2
                    return RedirectToAction("Index", "Home");
                }

            }

            else
            {    // caso o usuario e senha forem invalidos voltar para a tela login novamente.
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                return View();
            }
        }
        //realizando o logout da página e pegando o usuario logado
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}