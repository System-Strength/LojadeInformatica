using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace loja_Info.Models
{
    public class modelProduto
    {
        [DisplayName("Código:")]
        public string cod_Prod { get; set; }

        [DisplayName("Nome:")]
        public string nome_Prod  { get; set; }

        [DisplayName("Marca:")]
        public string marca_Prod  { get; set; }

        [DisplayName("Categoria:")]
        public string categoria_Prod  { get; set; }

        [DisplayName("Valor R$:")]
        public string valor_Prod  { get; set; }

        [DisplayName("Quantidade:")]
        public string qtd_Prod  { get; set; }
    }
}