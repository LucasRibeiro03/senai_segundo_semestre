using SENAI.Autopecas.WebApi.Domains;
using SENAI.Autopecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Autopecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public void Atualizar(Fornecedores fornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                //achar
                Fornecedores fornecedorEncontrado = ctx.Fornecedores.FirstOrDefault(x => x.IdFornecedor == fornecedor.IdFornecedor);
                //alterar
                fornecedorEncontrado.NomeFornecedor = fornecedor.NomeFornecedor;
                fornecedorEncontrado.Cnpj = fornecedor.Cnpj;
                fornecedorEncontrado.RazaoSocial = fornecedor.RazaoSocial;
                fornecedorEncontrado.Endereco = fornecedor.Endereco;
                fornecedorEncontrado.IdUsuario = fornecedor.IdUsuario;
                //update
                ctx.Fornecedores.Update(fornecedorEncontrado);

                //salvar
                ctx.SaveChanges();
                
            }
        }

        public Fornecedores BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.FirstOrDefault(x => x.IdFornecedor == id);
            }
        }

        public void Cadastrar(Fornecedores fornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Fornecedores.Add(fornecedor);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                //achar
                Fornecedores fornecedorEncontrado = ctx.Fornecedores.Find(id);
                //deletar
                ctx.Fornecedores.Remove(fornecedorEncontrado);
                //atualizar
                ctx.SaveChanges();
            }
        }

        public List<Fornecedores> listar()
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.ToList();

            }
        }
    }
}
