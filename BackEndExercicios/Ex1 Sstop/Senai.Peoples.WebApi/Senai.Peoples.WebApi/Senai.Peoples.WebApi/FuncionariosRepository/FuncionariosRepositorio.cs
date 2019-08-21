using Senai.Peoples.WebApi.FuncionariosDomains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.FuncionariosRepository
{
    public class FuncionariosRepositorio
    {
        private string stringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";

        public List<FuncionariosDomain> Listar()
        {
            //Buscar os dados do banco de dados
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();
            //Chamar o banco 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string Query = "Select IdFuncionario,NomeFuncionario,SobrenomeFuncionario from Funcionarios" ;
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            NomeFuncionario = sdr["NomeFuncionario"].ToString(),
                            SobrenomeFuncionario = sdr["SobrenomeFuncionario"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }

            }
           

            return funcionarios;
        }
        public FuncionariosDomain BuscarPorId(int id)
        {
            string Query = "SELECT * From Funcionarios WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if(sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionariosDomain funcionario = new FuncionariosDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                NomeFuncionario = sdr["NomeFuncionario"].ToString(),
                                SobrenomeFuncionario = sdr["SobrenomeFuncionario"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null; 
                }


            }




        }
        public void Cadastrar(FuncionariosDomain funcionariosDomain)
        {
            string Query = "INSERT INTO Funcionarios(NomeFuncionario,SobrenomeFuncionario) Values (@Nome,@Sobrenome)";
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionariosDomain.NomeFuncionario);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionariosDomain.SobrenomeFuncionario);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }





        }
        public void Atualizar(FuncionariosDomain funcionariosDomain)
        {
            string Query = "UPDATE Funcionarios SET nomeFuncionario = @Nome, sobrenomeFuncionario = @Sobrenome WHERE IdFuncionario = @Id";
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionariosDomain.NomeFuncionario);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionariosDomain.SobrenomeFuncionario);
                cmd.Parameters.AddWithValue("@Id", funcionariosDomain.IdFuncionario);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
