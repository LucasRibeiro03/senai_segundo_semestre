using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public void Atualizar(Plataformas plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataformaBuscada = ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == plataforma.IdPlataforma);

                plataformaBuscada.NomePlataforma = plataforma.NomePlataforma;

                ctx.Plataformas.Update(plataformaBuscada);

                ctx.SaveChanges();
            }
        }

        public Plataformas BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }

        public void Cadastrar(Plataformas plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataformas.Add(plataforma);
                ctx.SaveChanges();
            }   
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataformaEncontrada = ctx.Plataformas.Find(id);

                ctx.Plataformas.Remove(plataformaEncontrada);

                ctx.SaveChanges();
            }
        }

        public List<Plataformas> listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.ToList();
            }
        }
    }
}
