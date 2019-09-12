using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IPlataformaRepository
    {
        void Cadastrar(Plataformas plataforma);
        //listar
        List<Plataformas> listar();

        //listarporid
        Plataformas BuscarPorId(int id);
        //atualizar
        void Atualizar(Plataformas plataforma);
        //deletar
        void Deletar(int id);
    }
}
