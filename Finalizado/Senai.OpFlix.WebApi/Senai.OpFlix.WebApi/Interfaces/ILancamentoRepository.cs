using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentoRepository
    {
        //cadastrar
        void Cadastrar(Lancamentos lancamento);
        //listar
        List<Lancamentos> listar();

        //listarporid
        Lancamentos BuscarPorId(int id);
        //atualizar
        void Atualizar(Lancamentos lancamento);
        //deletar
        void Deletar(int id);
    }
}
