using loja_Info.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace loja_Info.Dados
{
    public class acoesVenda
    {
        conexao con = new conexao();


        //  Método para realizar uma venda
        public void inserirVenda(modelVenda venda)
        {

            //  Inserindo no banco de dados a venda
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Vendas (cod_Vendas, cod_Cli, endereco_Cli, cel_Cli, cod_Prod, qtd_Prod, cod_Pagamento) values(default, @cod_Cli, @endereco_Cli, @cel_Cli, @cod_Prod, @qtd_Prod, @cod_Pagamento)", con.MyConectarBD());


            cmd.Parameters.Add("@cod_Cli", MySqlDbType.VarChar).Value = venda.cod_Cliente;
            cmd.Parameters.Add("@endereco_Cli", MySqlDbType.VarChar).Value = venda.endereco_Cli;
            cmd.Parameters.Add("@cel_Cli", MySqlDbType.VarChar).Value = venda.cel_Cli;
            cmd.Parameters.Add("@cod_Prod", MySqlDbType.VarChar).Value = venda.cod_Produto;
            cmd.Parameters.Add("@qtd_Prod", MySqlDbType.VarChar).Value = venda.qtd_Prod;
            cmd.Parameters.Add("@cod_Pagamento", MySqlDbType.VarChar).Value = venda.cod_Pagamento;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Deu um erro aqui: " + ex);
            }
            con.MyDesconectarBD();
        }

        public List<modelVenda> GetVendaCons()//obtem os dados da venda
        {
            List<modelVenda> Atendlist = new List<modelVenda>();

            MySqlCommand cmd = new MySqlCommand("select tbl_Vendas.cod_Vendas, tbl_Cliente.nome_Cli, tbl_Cliente.endereco_Cli, tbl_Cliente.cel_Cli, tbl_Produto.nome_Prod, tbl_Vendas.qtd_Prod, tbl_Pagamento.forma_Pagamento from tbl_Vendas, tbl_Cliente, tbl_Produto, tbl_Pagamento where tbl_Vendas.cod_Cli = tbl_Cliente.cod_Cli and tbl_Vendas.cod_Prod = tbl_Produto.cod_Prod and tbl_Vendas.cod_Pagamento = tbl_Pagamento.cod_Pagamento;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sd.Fill(dt);

            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Atendlist.Add(
                    new modelVenda
                    {
                        cod_Vendas = Convert.ToString(dr["cod_Vendas"]),
                        nome_Cli = Convert.ToString(dr["nome_Cli"]),
                        endereco_Cli = Convert.ToString(dr["endereco_Cli"]),
                        cel_Cli = Convert.ToString(dr["cel_Cli"]),
                        nome_Prod = Convert.ToString(dr["nome_Prod"]),
                        qtd_Prod = Convert.ToString(dr["qtd_Prod"]),
                        forma_Pagamento = Convert.ToString(dr["forma_Pagamento"])
                    });
            }
            return Atendlist;
        }
    }
}
