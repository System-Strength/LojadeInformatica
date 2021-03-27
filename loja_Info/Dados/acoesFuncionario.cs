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

        //  MÉTODO PARA INSERIR FUNCIONÁRIO
        public void inserirFuncionario(modelFuncionario funcionario)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Funcionario (nome_Func, cel_Func, endereco_Func, cargo_Func, rg_Func, senha_Func, tipo_Func) values(@NomeFunc, @CelFunc, @EndFunc, @CargoFunc, @RgFunc, @SenhaFunc, @TipoFunc)", con.MyConectarBD());

            //  Mecanismo para geração da senha do funcionario
            Random rnd = new Random();
            int senhaNum = rnd.Next(10, 49);
            //  Armazenando senha gerada e inserindo diferencial "FUNC"
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

        //  Método para buscar informações de um funcionário
        public List<modelFuncionario> BuscarFuncionario()
        {
            //  Criando uma lista de funcionário para armazenar as informações recebida do banco de dados
            List<modelFuncionario> Funlist = new List<modelFuncionario>();

            //  Realizando consulta ao banco de dados
            MySqlCommand cmd = new MySqlCommand("select * from tbl_Funcionario", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            //  Adicionando os dados recebido na lista de funcionário
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
                        TipoFunc = Convert.ToString(dr["tipo_Func"])
                    });
            }
            return Funlist;
        }

        //  Método para editar um funcionário
        public bool editarFuncionario(modelFuncionario smodel)
        {
            //  Realizando update do funcionário no banco de dados
            MySqlCommand cmd = new MySqlCommand("update tbl_Funcionario set nome_Func=@nome_Func, cel_Func=@cel_Func, endereco_Func=@endereco_Func, cargo_Func=@cargo_Func, rg_Func=@rg_Func, senha_Func=@senha_Func, tipo_Func=@tipo_Func where cod_Func=@cod_Func", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cod_Func", smodel.CodFunc);
            cmd.Parameters.AddWithValue("@nome_Func", smodel.NomeFunc);
            cmd.Parameters.AddWithValue("@cel_Func", smodel.CelFunc);
            cmd.Parameters.AddWithValue("@endereco_Func", smodel.EndFunc);
            cmd.Parameters.AddWithValue("@cargo_Func", smodel.CargoFunc);
            cmd.Parameters.AddWithValue("@rg_Func", smodel.RgFunc);
            cmd.Parameters.AddWithValue("@senha_Func", smodel.SenhaFunc);
            cmd.Parameters.AddWithValue("@tipo_Func", smodel.TipoFunc);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //  Método para deleter um funcionário
        public bool DeleteFuncionario(int id)
        {
            //  Deletando funcionário do banco de dados
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