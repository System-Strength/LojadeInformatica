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

        acoesFuncionario acFun = new acoesFuncionario();

        public ActionResult cadFuncionario() //VIEW DO CADASTRAMENTO DO FUNCIONÁRIO
        {
            if (Session["usuarioLogado"] == null && Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)//O FUNCIONÁRIO NÃO CONSEGUE CADASTRAR OUTRO FUNCIONÁRIO
            {
                return RedirectToAction("Index", "Home");//ENTÃO ELE SERÁ REDIRECIONADA PARA A HOME
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult cadFuncionario(modelFuncionario fun) //FAZ O INSERT DO FUNCIONÁRIO
        {
            acFun.inserirFuncionario(fun);
            return RedirectToAction("listarFuncionario");
        }

        public ActionResult listarFuncionario() // LISTA DO FUNCIONÁRIO
        {
            if (Session["usuarioLogado"] == null && Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)//O FUNCIONÁRIO NÃO CONSEGUE VER OUTROS FUNCIONÁRIOS
            {
                return RedirectToAction("Index", "Home");//ENTÃO ELE SERÁ REDIRECIONADA PARA A HOME
            }
            else
            {
                ModelState.Clear();
                return View(acFun.BuscarFuncionario());//CASO SEJA GERENTE O USUÁRIO LOGADO, ELE IRÁ BUSCAR O FUNCIONÁRIO
            }
        }

        public ActionResult editarFuncionario(string id) // VIEW PARAR EDITAR FUNCIONÁRIO
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)//O FUNCIONÁRIO NÃO CONSEGUE EDITAR OUTROS FUNCIONÁRIOS
            {
                return RedirectToAction("Index", "Home");//ENTÃO ELE SERÁ REDIRECIONADA PARA A HOME
            }
            else
            {
                acoesFuncionario sdb = new acoesFuncionario();
                return View(sdb.BuscarFuncionario().Find(smodel => smodel.CodFunc == id));
            }
        }

        [HttpPost]
        public ActionResult editarFuncionario(int id, modelFuncionario smodel) // FAZ O UPDATE DO FUNCIONÁRIO
        {
            try //TENTA EDITAR FUNCIONÁRIO
            {
                acoesFuncionario sdb = new acoesFuncionario();
                sdb.editarFuncionario(smodel);
                return RedirectToAction("listarFuncionario");
            }
            catch (Exception ex)//CASO NÃO CONSIGA ELE DARÁ UM ERRO NO NOSSO LOG
            {
                System.Diagnostics.Debug.WriteLine("Deu um erro aqui: " + ex);
                return RedirectToAction("listarFuncionario");
            }
        }

        public ActionResult excluirFuncionario(int id, modelFuncionario fun) //VIEW PARA EXCLUIR O FUNCIONÁRIO
        {
            if (Session["usuarioLogado"] == null && Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else if (Session["tipoLogado1"] != null)//O FUNCIONÁRIO NÃO CONSEGUE EXCLUIR OUTROS FUNCIONÁRIOS
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try //TENTA EXCLUIR FUNCIONÁRIO
                {
                    acoesFuncionario sdb = new acoesFuncionario();

                    if (sdb.DeleteFuncionario(id))//SE ACHAR O CÓDIGO DO FUNCIONÁRIO IRÁ EXCLUIR
                    {
                        ViewBag.AlertMsg = "Funcionário excluído com sucesso";
                    }
                    return RedirectToAction("listarFuncionario");
                }

                catch//CASO NÃO CONSIGA ELE IRÁ RECARREGAR A PÁGINA
                {
                    return View();
                }
            }

        }


        //ABAIXO SÃO CÓDIGOS RELACIONADOS AO CLIENTE

        acoesCliente acCli = new acoesCliente();

        public ActionResult cadCliente() //VIEW PARA CADASTRAR O CLIENTE
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult cadCliente(modelCliente cli) //FAZ O INSERT DO CLIENTE
        {
            acCli.inserirCliente(cli);
            return RedirectToAction("listarCliente");
        }

        public ActionResult listarCliente() //LISTA TODOS OS CLIENTES
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
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

        public ActionResult cadProduto() //VIEW PARA CADASTRAR O PRODUTO
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult cadProduto(modelProduto produto) //FAZ O INSERT DO PRODUTO
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                try
                {
                    acProd.inserirProduto(produto);
                    return RedirectToAction("listarProduto");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Deu um erro aqui: " + ex);
                    return View();
                }
            }
        }

        public ActionResult listarProduto() // VIEW DA LISTA DOS PRODUTOS 
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ModelState.Clear();
                return View(acProd.BuscarProduto());
            }
        }

        public ActionResult editarProduto(string id) // VIEW PARA EDITAR OS PRODUTOS
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(acProd.BuscarProduto().Find(produto => produto.cod_Prod == id));
            }
        }

        [HttpPost]
        public ActionResult editarProduto(modelProduto produto) //FAZ O UPDATE DOS PRODUTOS
        {
            try
            {
                acoesProduto sdb = new acoesProduto();
                sdb.editarProduto(produto);
                return RedirectToAction("listarProduto");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Deu um erro aqui: " + ex);
                return View();
            }
        }

        public ActionResult excluirProduto(int id, modelProduto produto) // VIEW PARA EXCLUIR OS PRODUTOS
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)//SÓ IRÁ LOGAR SE OS CAMPOS ESTIVEREM PREENCHIDOS
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

        //ABAIXO SÃO CÓDIGOS RELACIONADOS A VENDA
        acoesVenda acoesVenda = new acoesVenda();

        public void carregaCliente() // TRAZ OS CLIENTES NA DROPLIST
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
        public void carregaProduto() // TRAZ OS PRODUTOS NA DROPLIST
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
        public void carregaFormaPag() //CARREGA AS FORMAS DE PAGAMENTO NA DROPLIST
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
        public ActionResult Venda() // VIEW DA VENDA
        {
            carregaCliente();
            carregaProduto();
            carregaFormaPag();
            return View();
        }


        [HttpPost]
        public ActionResult Venda(modelVenda venda) //REALIZA A VENDA
        {
            carregaCliente();
            carregaProduto();
            carregaFormaPag();
            venda.cod_Cliente = Request["cliente"];
            venda.cod_Produto = Request["produto"];
            venda.cod_Pagamento = Request["pagamento"];
            if (venda.qtd_Prod != null//SE A QUANTIDADE DO PRODUTO NÃO ESTIVER NULO, REALIZA A VENDA
            {
                acoesVenda.inserirVenda(venda);
                ViewBag.msg = "Venda Realizada";
                return RedirectToAction("listarVendas");
            }
            else//SE A QUANTIDADE DO PRODUTO ESTIVER NULA, NÃO REALIZA A VENDA
            {
                ViewBag.msg = "Produto indisponível";
                return View();
            }

        }
        public ActionResult listarVendas() //LISTA AS VENDAS FEITAS
        {
            acoesVenda dbhandle = new acoesVenda();
            ModelState.Clear();
            return View(dbhandle.GetVendaCons());
        }
    }
}
