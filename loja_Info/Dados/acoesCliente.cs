using loja_Info.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace loja_Info.Dados
{
    public class acoesCliente
    {
        conexao con = new conexao();

        public void inserirCliente(modelCliente cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Cliente (nome_Cli, email_Cli, endereco_Cli, cel_Cli )values(@nome_Cli, @email_Cli, @endereco_Cli, @cel_Cli)", con.MyConectarBD());
            cmd.Parameters.Add("@nome_Cli", MySqlDbType.VarChar).Value = cm.nome_Cli;
            cmd.Parameters.Add("@email_Cli", MySqlDbType.VarChar).Value = cm.email_Cli;
            cmd.Parameters.Add("@endereco_Cli", MySqlDbType.VarChar).Value = cm.endereco_Cli;
            cmd.Parameters.Add("@cel_Cli", MySqlDbType.VarChar).Value = cm.cel_Cli;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
        public List<modelCliente> BuscarCliente()
        {
            List<modelCliente> Clilist = new List<modelCliente>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_Cliente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Clilist.Add(
                    new modelCliente
                    {
                        cod_Cli = Convert.ToString(dr["cod_Cli"]),
                        nome_Cli = Convert.ToString(dr["nome_Cli"]),
                        email_Cli = Convert.ToString(dr["email_Cli"]),
                        endereco_Cli = Convert.ToString(dr["endereco_Cli"]),
                        cel_Cli = Convert.ToString(dr["cel_Cli"])
                    });
            }
            return Clilist;
        }
    }
}
