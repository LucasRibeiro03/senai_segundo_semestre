using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public void Atualizar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //buscar
                Lancamentos lancamentoEncontrado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
                //atualizar
                lancamentoEncontrado.IdPlataforma = lancamento.IdPlataforma;
                lancamentoEncontrado.IdCategoria = lancamento.IdCategoria;
                lancamentoEncontrado.NomeLancamento = lancamento.NomeLancamento;
                lancamentoEncontrado.Sinopse = lancamentoEncontrado.Sinopse;

                //update
                ctx.Lancamentos.Update(lancamentoEncontrado);
                //salvar
                ctx.SaveChanges();
            }
        }

        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);

            }
        }

        public void Cadastrar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //achar
                Lancamentos lancamentoDeletar = ctx.Lancamentos.Find(id);
                //deletar
                ctx.Lancamentos.Remove(lancamentoDeletar);
                //salvar
                ctx.SaveChanges();

            }
        }

        public List<Lancamentos> listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.ToList();
            }
        }
    }
}
