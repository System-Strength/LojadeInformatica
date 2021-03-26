using loja_Info.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace loja_Info.Dados
{
    public class acoesFuncionario
    {
        conexao con = new conexao();

        //MÉTODO PARA INSERIR FUNCIONÁRIO
        public void inserirFuncionario(modelFuncionario funcionario)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Funcionario (nome_Func, cel_Func, endereco_Func, cargo_Func, rg_Func, senha_Func, tipo_Func) values(@NomeFunc, @CelFunc, @EndFunc, @CargoFunc, @RgFunc, @SenhaFunc, @TipoFunc)", con.MyConectarBD());

            //  Mecanismo para geração da senha do funcionario
            Random rnd = new Random();
            int senhaNum = rnd.Next(1001, 20000);
            String senha_gerada = "func" + senhaNum;

            cmd.Parameters.Add("@NomeFunc", MySqlDbType.VarChar).Value = funcionario.NomeFunc;
            cmd.Parameters.Add("@CelFunc", MySqlDbType.VarChar).Value = funcionario.CelFunc;
            cmd.Parameters.Add("@EndFunc", MySqlDbType.VarChar).Value = funcionario.EndFunc;
            cmd.Parameters.Add("@RgFunc", MySqlDbType.VarChar).Value = funcionario.RgFunc;
            cmd.Parameters.Add("@CargoFunc", MySqlDbType.VarChar).Value = funcionario.CargoFunc;
            cmd.Parameters.Add("@SenhaFunc", MySqlDbType.VarChar).Value = senha_gerada;
            cmd.Parameters.Add("@TipoFunc", MySqlDbType.VarChar).Value = funcionario.TipoFunc;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelFuncionario> BuscarFuncionario()
        {
            List<modelFuncionario> Funlist = new List<modelFuncionario>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_Funcionario", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Funlist.Add(
                    new modelFuncionario
                    {
                        CodFunc = Convert.ToString(dr["cod_Func"]),
                        NomeFunc = Convert.ToString(dr["nome_Func"]),
                        RgFunc = Convert.ToString(dr["rg_Func"]),
                        CargoFunc = Convert.ToString(dr["cargo_Func"]),
                        EndFunc = Convert.ToString(dr["endereco_Func"]),
                        CelFunc = Convert.ToString(dr["cel_Func"]),
                        SenhaFunc = Convert.ToString(dr["senha_Func"]),
                        TipoFunc = Convert.ToString(dr["tipo_Func"]),
                    });
            }
            return Funlist;
        }

        public bool atualizaFuncionario(modelFuncionario funcionario)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_Funcionario set nome_Func=@NomeFunc, cel_Func=@CelFunc, endereco_Func=@EndFunc, cargo_Func=@CargoFunc, rg_Func=@RgFunc, senha_Func=@SenhaFunc and tipo_Func=@TipoFunc where cod_Func=@CodFunc", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@NomeFunc", funcionario.NomeFunc);
            cmd.Parameters.AddWithValue("@CelFunc", funcionario.CelFunc);
            cmd.Parameters.AddWithValue("@EndFunc", funcionario.EndFunc);
            cmd.Parameters.AddWithValue("@CargoFunc", funcionario.CargoFunc);
            cmd.Parameters.AddWithValue("@RgFunc", funcionario.RgFunc);
            cmd.Parameters.AddWithValue("@SenhaFunc", funcionario.SenhaFunc);
            cmd.Parameters.AddWithValue("@TipoFunc", funcionario.TipoFunc);
            cmd.Parameters.AddWithValue("@CodFunc", funcionario.CodFunc);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;

            else
                return false;

        }

        public bool DeleteFuncionario(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_Funcionario where cod_Func=@CodFunc", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@CodFunc", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}