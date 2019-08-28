using SENAI.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Ekips.WebApi.Repositories
{
    public class CargosRepository
    {
        Cargos cargo = new Cargos();

        //Listar Cargo

        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
                {
                return ctx.Cargos.ToList();
            }
        }
        //Buscar Cargo por Id

        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }
        //Cadastrar Cargo
        public void Cadastrar(Cargos cargo)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();
            }
        }
        //Atualizar Cargo
        public void Atualizar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargos cargoEncontrado = ctx.Cargos.FirstOrDefault(x => x.IdCargo == cargo.IdCargo);
                cargoEncontrado.NomeCargo = cargo.NomeCargo;
                ctx.Cargos.Update(cargoEncontrado);
                ctx.SaveChanges();
                  
            }
        }
        //Deletar cargo
        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargos cargo = ctx.Cargos.Find(id);

                ctx.Cargos.Remove(cargo);

                ctx.SaveChanges();
            }
        }

    }
}
