using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace loja_Info.Models
{
    public class modelCliente
    {
        //DADOS QUE VEM DO BANCO

        [DisplayName("Código:")]
        public string cod_Cli { get; set; }

        [DisplayName("Nome:")]
        public string nome_Cli { get; set; }

        [DisplayName("Celular:")]
        public string cel_Cli { get; set; }

        [DisplayName("Email:")]
        public string email_Cli { get; set; }

        [DisplayName("Endereço:")]
        public string endereco_Cli { get; set; }

    }
}