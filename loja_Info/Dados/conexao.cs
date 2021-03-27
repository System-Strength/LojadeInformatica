using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loja_Info.Dados
{
    public class conexao
    {
        //  Estabelecendo informações para conexão ao banco de dados
        MySqlConnection cn = new MySqlConnection("Server=localhost;DataBase=bdloja;User=root;pwd=123456789");
        public static string msg;

        //  Método para conectar ao banco de dados
        public MySqlConnection MyConectarBD()
        {
            try
            {
                cn.Open();
            }

            catch (Exception ex)
            {
                msg = "Ocorreu um erro ao se conectar: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return cn;
        }

        //  Método para fechar conexão ao banco de dados
        public MySqlConnection MyDesconectarBD()
        {
            try
            {
                cn.Close();
            }

            catch (Exception ex)
            {
                msg = "Ocorreu um erro ao se conectar: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return cn;
        }
    }
}