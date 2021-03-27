using loja_Info.Dados;
using loja_Info.Models;
using MySql.Data.MySqlClient;
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

        public ActionResult listarFuncionario()
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
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                acoesFuncionario sdb = new acoesFuncionario();
                return View(sdb.BuscarFuncionario().Find(smodel => smodel.CodFunc == id));
            }
        }

        [HttpPost]
        public ActionResult editarFuncionario(int id, modelFuncionario smodel)
        {
            try
            {
                acoesFuncionario sdb = new acoesFuncionario();
                sdb.editarFuncionario(smodel);
                return RedirectToAction("listarFuncionario");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Deu um erro aqui: " + ex);
                return RedirectToAction("listarFuncionario");
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
            {
                acProd.inserirProduto(produto);
                ViewBag.confCadastro = "Cadastro Realizado com sucesso";
                return View();
            }
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
        public ActionResult editarProduto(modelProduto produto)
        {
            try
            {
                acoesProduto sdb = new acoesProduto();
                sdb.editarProduto(produto);
                return RedirectToAction("listarProduto");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Deu um erro aqui: " + ex);
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
            //ABAIXO SÃO CÓDIGOS RELACIONADOS A VENDA

            acoesVenda acoesVenda = new acoesVenda();

            public void carregaCliente()
            {
                List<SelectListItem> cli = new List<SelectListItem>();

                using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdloja;User=root;pwd=123456789"))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from tbl_Cliente order by nome_Cli;", con);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        cli.Add(new SelectListItem
                        {
                            Text = rdr[1].ToString(),
                            Value = rdr[0].ToString()
                        });
                    }

                    con.Close();
                    con.Open();
                }

                ViewBag.cliente = new SelectList(cli, "Value", "Text");
            }
            public void carregaProduto()
            {
                List<SelectListItem> prod = new List<SelectListItem>();

                using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdloja;User=root;pwd=123456789"))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from tbl_Produto order by nome_Prod;", con);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        prod.Add(new SelectListItem
                        {
                            Text = rdr[1].ToString(),
                            Value = rdr[0].ToString()
                        });
                    }

                    con.Close();
                    con.Open();
                }

                ViewBag.produto = new SelectList(prod, "Value", "Text");
            }
            public void carregaFormaPag()
            {
                List<SelectListItem> pag = new List<SelectListItem>();

                using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdloja;User=root;pwd=123456789"))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from tbl_Pagamento order by forma_Pagamento;", con);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        pag.Add(new SelectListItem
                        {
                            Text = rdr[1].ToString(),
                            Value = rdr[0].ToString()
                        });
                    }

                    con.Close();
                    con.Open();
                }

                ViewBag.pagamento = new SelectList(pag, "Value", "Text");
            }
            public ActionResult Venda()
            {
                carregaCliente();
                carregaProduto();
                carregaFormaPag();
                return View();
            }


            [HttpPost]
            public ActionResult Venda(modelVenda venda)
            {
                carregaCliente();
                carregaProduto();
                carregaFormaPag();
                venda.cod_Cliente = Request["cliente"];
                venda.cod_Produto = Request["produto"];
                venda.forma_Pagamento = Request["pagamento"];
                ac.TestarAgenda(venda);

                if (venda.confAgendamento == "1")
                {
                    ac.inserirAtendimento(venda);
                    ViewBag.msg = "Agendamento Realizado";
                    return View();
                }

                else if (venda.confAgendamento == "0")
                {
                    ViewBag.msg = "Horário indisponível";
                    return View();
                }

                return View();

            }
        }
    }
}
