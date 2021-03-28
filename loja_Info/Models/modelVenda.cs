using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace loja_Info.Models
{
    public class modelVenda
    {
        //DADOS QUE VEM DO BANCO

        [DisplayName("Código:")]
        public string cod_Vendas { get; set; }
        
        [DisplayName("Nome do Cliente:")]
        public string nome_Cli { get; set; }

        [DisplayName("Endereço do cliente:")]
        public string endereco_Cli { get; set; }

        [DisplayName("Celular do Cliente:")]
        public string cel_Cli { get; set; }

        [DisplayName("Nome do Produto:")]
        public string nome_Prod { get; set; }

        [DisplayName("Quantidade:")]
        public string qtd_Prod { get; set; }

        [DisplayName("Forma de pagamento:")]
        public string forma_Pagamento { get; set; }

        [DisplayName("Código do Cliente:")]
        public string cod_Cliente { get; set; }

        [DisplayName("Código do Produto:")]
        public string cod_Produto { get; set; }

        [DisplayName("Código do Pagamento:")]
        public string cod_Pagamento { get; set; }
    }
}