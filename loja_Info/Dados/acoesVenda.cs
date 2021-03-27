using loja_Info.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Venda (cod_Vendas, nome_Cli, endereco_Cli, cel_Cli, nome_Prod, qtd_Prod, forma_Pagamento) values(default, @nome_Cli, @endereco_Cli, @cel_Cli, @nome_Prod, @qtd_Prod, @forma_Pagamento)", con.MyConectarBD());


            cmd.Parameters.Add("@nome_Cli", MySqlDbType.VarChar).Value = venda.nome_Cli;
            cmd.Parameters.Add("@endereco_Cli", MySqlDbType.VarChar).Value = venda.endereco_Cli;
            cmd.Parameters.Add("@cel_Cli", MySqlDbType.VarChar).Value = venda.cel_Cli;
            cmd.Parameters.Add("@nome_Prod", MySqlDbType.VarChar).Value = venda.nome_Prod;
            cmd.Parameters.Add("@qtd_Prod", MySqlDbType.VarChar).Value = venda.qtd_Prod;
            cmd.Parameters.Add("@forma_Pagamento", MySqlDbType.VarChar).Value = venda.forma_Pagamento;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}