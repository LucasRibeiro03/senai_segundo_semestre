using System;
using System.Collections.Generic;

namespace SENAI.Ekips.WebApi.Domains
{
    public partial class Cargos
    {
        public Cargos()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdCargo { get; set; }
        public string NomeCargo { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
