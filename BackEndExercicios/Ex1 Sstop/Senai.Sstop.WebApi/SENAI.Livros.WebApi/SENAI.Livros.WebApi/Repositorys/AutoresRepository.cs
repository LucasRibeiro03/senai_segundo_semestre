using SENAI.Livros.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Livros.WebApi.Repositorys
{
    public class AutoresRepository
    {

        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Livros;User Id=sa;Pwd=132;";

        public List<AutoresDomain> Listar()
        {


            List<AutoresDomain> autores = new List<AutoresDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdAutores,NomeAutor FROM Autores;";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        AutoresDomain autor = new AutoresDomain
                        {
                            IdAutor = Convert.ToInt32(sdr["IdAutores"]),
                            NomeAutor = sdr["NomeAutor"].ToString()
                        };
                    autores.Add(autor);
                    }
                }
            }
                return autores;
        }

        public void Cadastrar(AutoresDomain autoresDomain)
        {
            string Query = "Insert into Autores(NomeAutor) values(@Nome);";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", autoresDomain.NomeAutor);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}
