using System;
using System.Collections.Generic;

namespace SENAI.Autopecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int IdPecas { get; set; }
        public string CodigoPeca { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }
        public string PrecoCusto { get; set; }
        public string PrecoVenda { get; set; }
        public int? FornecedorVinculado { get; set; }

        public Fornecedores FornecedorVinculadoNavigation { get; set; }
    }
}
