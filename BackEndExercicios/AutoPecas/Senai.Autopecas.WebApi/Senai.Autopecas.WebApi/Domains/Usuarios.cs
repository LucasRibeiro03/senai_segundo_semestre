﻿using System;
using System.Collections.Generic;

namespace SENAI.Autopecas.WebApi.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Fornecedores Fornecedores { get; set; }
    }
}
