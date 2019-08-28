using System;
using System.Collections.Generic;

namespace SENAI.Ekips.WebApi.Domains
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdDepartamento { get; set; }
        public string Nome { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
