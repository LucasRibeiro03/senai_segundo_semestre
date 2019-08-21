using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.GenerosRepositories
{
    public class GeneroRepositories
    {
        private string stringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";

        public List<GeneroDomain> Listar()

        {
            //Buscar os dados do banco de dados

            List<GeneroDomain> generos = new List<GeneroDomain>();
            //chamar o  banco
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string Query = "Select IdEstiloMusical, Nome From EstilosMusicais";
                //Abrir a conexao
                con.Open();
                //declaro para percorrer a  lista
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        GeneroDomain Genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdEstiloMusical"]),
                            Nome = sdr["Nome"].ToString()

                        };
                        generos.Add(Genero);
                    }

                }
            }

            //Execitar o select
            //Retornar as informacoes
            return generos;
        }

    }
}
