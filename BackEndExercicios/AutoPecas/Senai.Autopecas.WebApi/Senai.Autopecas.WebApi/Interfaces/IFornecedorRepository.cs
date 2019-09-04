using SENAI.Autopecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Autopecas.WebApi.Interfaces
{
    public interface IFornecedorRepository
    {
        //cadastrar
        void Cadastrar(Fornecedores fornecedor);
        //listar
        List<Fornecedores> listar();

        //listarporid
        Fornecedores BuscarPorId(int id);
        //atualizar
        void Atualizar(Fornecedores fornecedor);
        //deletar
        void Deletar(int id);
    }
}
