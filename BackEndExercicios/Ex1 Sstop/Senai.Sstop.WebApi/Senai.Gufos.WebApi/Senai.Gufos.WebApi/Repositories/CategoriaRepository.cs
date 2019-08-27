using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    public class CategoriaRepository
    {
        public List<Categorias> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                //Facilitar o processo
                //select
                return ctx.Categorias.ToList();
            }
        }
        public void Cadastrar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                //Insert into categoria(nome) values (@nome);
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();

            }
        }//buscar por Id
        public Categorias BuscarPorId(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }
        //Adicionar

            public void Atualizar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);

                CategoriaBuscada.Nome = categoria.Nome ;

                ctx.Categorias.Update(CategoriaBuscada);
                ctx.SaveChanges();
            }
        }
        //Deletar

        public void Deletar(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                //encontrar o item                        1
                //chave primaria da tabela                
                // remover do contexto                    2
                //efetuar as mudanças no banco de dados  3

                //1
                Categorias categoria = ctx.Categorias.Find(id);
                //2
                ctx.Categorias.Remove(categoria);
                //3
                ctx.SaveChanges();
                
            }
        }
    }
}
