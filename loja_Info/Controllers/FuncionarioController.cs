using loja_Info.Dados;
using loja_Info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loja_Info.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }

        acoesFuncionario acFun = new acoesFuncionario();

        public ActionResult cadFuncionario()
        {
            if (Session["usuarioLogado"] == null && Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult cadFuncionario(modelFuncionario fun)
        {
            acFun.inserirFuncionario(fun);
            ViewBag.confCadastro = "Cadastro Realizado com sucesso";
            return View();
        }

        public ActionResult listarFuncionario(modelFuncionario fun)
        {
            if (Session["usuarioLogado"] == null && Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.Clear();
                return View(acFun.BuscarFuncionario());
            }
        }

        public ActionResult editarFuncionario(string id)
        {
            if (Session["usuarioLogado"] == null && Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(acFun.BuscarFuncionario().Find(funcionario => funcionario.CodFunc == id));
            }
        }

        [HttpPost]
        public ActionResult editarFuncionario(int id, modelFuncionario funcionario)
        {
            try
            {
                acoesFuncionario sdb = new acoesFuncionario();
                sdb.atualizaFuncionario(funcionario);
                return RedirectToAction("listarFuncionario");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult excluirFuncionario(int id, modelFuncionario fun)
        {
            if (Session["usuarioLogado"] == null && Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    acoesFuncionario sdb = new acoesFuncionario();

                    if (sdb.DeleteFuncionario(id))
                    {
                        ViewBag.AlertMsg = "Funcionário excluído com sucesso";
                    }
                    return RedirectToAction("listarFuncionario");
                }

                catch
                {
                    return View();
                }
            }
            
        }


        //ABAIXO SÃO CÓDIGOS RELACIONADOS AO CLIENTE

        acoesCliente acCli = new acoesCliente();

        public ActionResult cadCliente()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult cadCliente(modelCliente cli)
        {
            acCli.inserirCliente(cli);
            ViewBag.confCadastro = "Cadastro Realizado com sucesso";
            return View();
        }

        public ActionResult listarCliente()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ModelState.Clear();
                return View(acCli.BuscarCliente());
            }
        }

        //ABAIXO SÃO CÓDIGOS RELACIONADOS AO PRODUTO

        acoesProduto acProd = new acoesProduto();

        public ActionResult cadProduto()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult cadProduto(modelProduto produto)
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            acProd.inserirProduto(produto);
            ViewBag.confCadastro = "Cadastro Realizado com sucesso";
            return View();
        }

        public ActionResult listarProduto(modelProduto produto)
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ModelState.Clear();
                return View(acProd.BuscarProduto());
            }
        }

        public ActionResult editarProduto(string id)
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(acProd.BuscarProduto().Find(produto => produto.cod_Prod == id)); 
            }
        }

        [HttpPost]
        public ActionResult editarProduto(int id, modelProduto produto)
        {
            try
            {
                acoesProduto sdb = new acoesProduto();
                sdb.atualizaProduto(produto);
                return RedirectToAction("listarProduto");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult excluirProduto(int id, modelProduto produto)
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                try
                {
                    acoesProduto sdb = new acoesProduto();

                    if (sdb.DeleteProduto(id))
                    {
                        ViewBag.AlertMsg = "Produto excluído com sucesso";
                    }
                    return RedirectToAction("listarProduto");
                }
                catch
                {
                    return View();
                }
            }

        }
    }
}
