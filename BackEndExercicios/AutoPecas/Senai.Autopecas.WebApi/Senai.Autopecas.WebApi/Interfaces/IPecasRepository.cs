using SENAI.Autopecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Autopecas.WebApi.Interfaces
{
    interface IPecasRepository
    {
        void Cadastrar(Pecas peca);

        List<Pecas> Listar();

        Pecas BuscarPorId(int id);

        void Atualizar(Pecas peca);

        void Deletar(int id);
    }
}
