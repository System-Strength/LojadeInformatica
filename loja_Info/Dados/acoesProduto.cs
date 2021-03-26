using loja_Info.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace loja_Info.Dados
{
    public class acoesProduto
    {
        conexao con = new conexao();

        public void inserirProduto(modelProduto produto)
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbl_Produto (nome_Prod, marca_Prod, categoria_Prod, valor_Prod, qtd_Prod) values(@NomeProd, @MarcaProd, @CatProd, @ValorProd, @Qtd_Prod)", con.MyConectarBD());

            cmd.Parameters.Add("@NomeProd", MySqlDbType.VarChar).Value = produto.nome_Prod;
            cmd.Parameters.Add("@MarcaProd", MySqlDbType.VarChar).Value = produto.marca_Prod;
            cmd.Parameters.Add("@CatProd", MySqlDbType.VarChar).Value = produto.categoria_Prod;
            cmd.Parameters.Add("@ValorProd", MySqlDbType.VarChar).Value = produto.valor_Prod;
            cmd.Parameters.Add("@Qtd_Prod", MySqlDbType.VarChar).Value = produto.qtd_Prod;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelProduto> BuscarProduto()
        {
            List<modelProduto> Prodlist = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_Produto", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Prodlist.Add(
                    new modelProduto
                    {
                        cod_Prod = Convert.ToString(dr["cod_Prod"]),
                        nome_Prod = Convert.ToString(dr["nome_Prod"]),
                        marca_Prod = Convert.ToString(dr["marca_Prod"]),
                        categoria_Prod = Convert.ToString(dr["categoria_Prod"]),
                        valor_Prod = Convert.ToString(dr["valor_Prod"]),
                        qtd_Prod = Convert.ToString(dr["qtd_Prod"]),
                    });
            }
            return Prodlist;
        }

        public bool atualizaProduto(modelProduto produto)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_Produto set nome_Prod=@nome_Prod, marca_Prod=@marca_Prod, qtd_Prod=@qtd_Prod, valor_Prod=@valor_Prod and categoria_Prod=@categoria_Prod where cod_Prod=@cod_Prod", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@nome_Prod", produto.nome_Prod);
            cmd.Parameters.AddWithValue("@marca_Prod", produto.marca_Prod);
            cmd.Parameters.AddWithValue("@qtd_Prod", produto.qtd_Prod);
            cmd.Parameters.AddWithValue("@valor_Prod", produto.valor_Prod);
            cmd.Parameters.AddWithValue("@categoria_Prod", produto.categoria_Prod);
            cmd.Parameters.AddWithValue("@cod_Prod", produto.cod_Prod);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool DeleteProduto(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_Produto where cod_Prod=@CodProd", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@CodProd", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}