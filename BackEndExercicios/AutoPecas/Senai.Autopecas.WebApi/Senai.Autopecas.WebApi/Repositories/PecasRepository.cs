using SENAI.Autopecas.WebApi.Domains;
using SENAI.Autopecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Autopecas.WebApi.Repositories
{
    public class PecasRepository : IPecasRepository
    {
        public void Atualizar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                //buscar
                Pecas pecaEncontrada = ctx.Pecas.FirstOrDefault(x => x.IdPecas == peca.IdPecas);
                //alterar
                pecaEncontrada.CodigoPeca = peca.CodigoPeca;
                pecaEncontrada.Descricao = peca.Descricao;
                pecaEncontrada.Peso = peca.Peso;
                pecaEncontrada.PrecoCusto = peca.PrecoCusto;
                pecaEncontrada.PrecoVenda = peca.PrecoVenda;
                pecaEncontrada.FornecedorVinculado = peca.FornecedorVinculado;
                //atualizar

                ctx.Pecas.Update(pecaEncontrada);
                //salvar
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                 return ctx.Pecas.FirstOrDefault(x => x.IdPecas == id);
            }
        }

        public void Cadastrar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                //achar
                Pecas pecaEncontrada = ctx.Pecas.Find(id);
                //deletar
                ctx.Pecas.Remove(pecaEncontrada);
                //atualizar
                ctx.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }
    }
}
