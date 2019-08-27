using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepositories
    {
        List<Estilos> estilos = new List<Estilos>();

        public List<Estilos> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                
                return ctx.Estilos.ToList();
            }
        }
        public void Cadastrar(Estilos estilo)
        {
            using (GufosContext ctx = new GufosContext())
            {
               
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();

            }

        }
        public Estilos BuscarPorId(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Atualizar(Estilos estilos)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilos.IdEstilo);

                EstiloBuscado.Nome = estilos.Nome;

                ctx.Estilos.Update(EstiloBuscado);
                ctx.SaveChanges();
            }
        }

    }
}
