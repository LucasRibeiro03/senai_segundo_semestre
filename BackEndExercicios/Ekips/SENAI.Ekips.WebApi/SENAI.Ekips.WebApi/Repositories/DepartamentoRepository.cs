using SENAI.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        Departamentos departamentos = new Departamentos();

        //Listar departamentos
        public List<Departamentos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.ToList();
            }
        }
        //Buscar departamentos por id 
        public Departamentos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }
        //Cadastrar
        public void cadastrar(Departamentos departamento)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Departamentos.Add(departamento);
                ctx.SaveChanges();
            }
        }
        //atualizar 
        public void Atualizar(Departamentos departamento)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Departamentos DepartamentoEncontrado = ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == departamento.IdDepartamento);
                DepartamentoEncontrado.Nome = departamento.Nome;
                ctx.Departamentos.Update(DepartamentoEncontrado);
                ctx.SaveChanges();
            }
        }

        //deletar
        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Departamentos depoimento = ctx.Departamentos.Find(id);

                ctx.Departamentos.Remove(depoimento);

                ctx.SaveChanges();
            }
        }
    }
}
