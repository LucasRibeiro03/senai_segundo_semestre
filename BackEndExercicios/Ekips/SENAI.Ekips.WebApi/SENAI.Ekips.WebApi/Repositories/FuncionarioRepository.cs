using Microsoft.EntityFrameworkCore;
using SENAI.Ekips.WebApi.Domains;
using SENAI.Ekips.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        //listarLogin

        //adicionar login
        public Funcionarios BuscarPorEmailESenha(LoginViewModel Login)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios funcionario = ctx.Funcionarios.Include(x => x.Permissao).FirstOrDefault(x => x.NomeFuncionario == Login.Email && x.Cpf == Login.Senha);
                if (funcionario == null)
                    return null;

                return funcionario;

            }
        }
        //cadastrar login

        //Atualizar


    }
}
