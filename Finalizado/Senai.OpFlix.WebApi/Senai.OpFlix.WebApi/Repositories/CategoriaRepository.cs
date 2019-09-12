using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Atualizar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {

            //achar 
                Categorias categoriaEncontrada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                //modificar
                categoriaEncontrada.NomeCategoria = categoria.NomeCategoria;
                //atualizar
                ctx.Categorias.Update(categoriaEncontrada);
                //salvar
                ctx.SaveChanges();
            }
        }

        public Categorias BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Cadastrar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //achar
                Categorias categoriaEncontrada = ctx.Categorias.Find(id);
                //deletar
                ctx.Remove(categoriaEncontrada);
                //salvar
                ctx.SaveChanges();


            }
        }

        public List<Categorias> listar()
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.ToList();
            }
        }
    }
}
