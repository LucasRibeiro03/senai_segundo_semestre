﻿using System;
using System.Collections.Generic;

namespace SENAI.Autopecas.WebApi.Domains
{
    public partial class Fornecedores
    {
        public Fornecedores()
        {
            Pecas = new HashSet<Pecas>();
        }

        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public int? IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Pecas> Pecas { get; set; }
    }
}
