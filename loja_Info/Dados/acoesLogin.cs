using loja_Info.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loja_Info.Dados
{
    public class acoesLogin
    {
        public void TestarUsuario(modelFuncionario funcionario)
        {

            conexao con = new conexao();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_Funcionario where rg_Func = @RgFunc and senha_Func = @SenhaFunc ", con.MyConectarBD());

            cmd.Parameters.Add("@RgFunc", MySqlDbType.VarChar).Value = funcionario.RgFunc;
            cmd.Parameters.Add("@SenhaFunc", MySqlDbType.VarChar).Value = funcionario.SenhaFunc;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    funcionario.RgFunc = Convert.ToString(leitor["rg_Func"]);
                    funcionario.SenhaFunc = Convert.ToString(leitor["senha_Func"]);
                    funcionario.TipoFunc = Convert.ToString(leitor["tipo_Func"]);
                }
            }

            else
            {
                funcionario.RgFunc = null;
                funcionario.SenhaFunc = null;
                funcionario.TipoFunc = null;
            }

            con.MyDesconectarBD();
        }
    }
}