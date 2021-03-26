using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace loja_Info.Models
{
    public class modelFuncionario
    {
        [DisplayName("Código:")]
        public string CodFunc { get; set; }

        [DisplayName("Nome:")]
        public string NomeFunc { get; set; }

        [DisplayName("RG:")]
        public string RgFunc { get; set; }

        [DisplayName("Cargo:")]
        public string CargoFunc { get; set; }

        [DisplayName("Endereço:")]
        public string EndFunc { get; set; }

        [DisplayName("Celular:")]
        public string CelFunc { get; set; }

        [DisplayName("Senha:")]
        public string SenhaFunc { get; set; }

        [DisplayName("Tipo:")]
        public string TipoFunc { get; set; }
    }
}