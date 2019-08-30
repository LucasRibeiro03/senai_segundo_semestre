using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SENAI.Ekips.WebApi.Domains
{
    public partial class Funcionarios
    {
        public int IdFuncionario { get; set; }
        public string NomeFuncionario { get; set; }
        public int? IdCargo { get; set; }
        public int? IdDepartamento { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Salario { get; set; }


        public Cargos IdCargoNavigation { get; set; }
        public Departamentos IdDepartamentoNavigation { get; set; }
        public ClaimsIdentity Permissao { get; internal set; }
    }
}
