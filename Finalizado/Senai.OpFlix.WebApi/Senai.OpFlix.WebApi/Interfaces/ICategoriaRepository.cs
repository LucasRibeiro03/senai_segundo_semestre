using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ICategoriaRepository
    {
        void Cadastrar(Categorias categoria);
        //listar
        List<Categorias> listar();

        //listarporid
        Categorias BuscarPorId(int id);
        //atualizar
        void Atualizar(Categorias categoria);
        //deletar
        void Deletar(int id);
    }
}
