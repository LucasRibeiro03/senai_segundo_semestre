using Optus2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optus2.Repositories
{
    public class EstiloRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }
        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // insert into categorias (nome) values (@nome);
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }
        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);

            }
        }
        public void deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos estilo = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(estilo);
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos estiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);

                estiloBuscado.Nome = estilo.Nome;

                ctx.Estilos.Update(estiloBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
