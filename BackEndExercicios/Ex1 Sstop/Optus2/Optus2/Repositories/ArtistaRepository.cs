using Microsoft.EntityFrameworkCore;
using Optus2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optus2.Repositories
{
    public class ArtistaRepository
    {
        public Artistas artista = new Artistas();

        //Listar
        public List<Artistas> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.Include(x => x.IdArtistaNavegation).ToList();
            }
        }
        //BuscarPorId
        public void Cadastrar(Artistas artista)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Artistas.Add(artista);
                ctx.SaveChanges();
            }
        }
        //Adicionar



    }
}
