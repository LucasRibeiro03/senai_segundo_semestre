using SENAI.Livros.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Livros.WebApi.Repositorys
{
    public class LivroRepository
    {
        private string StringConexao = "Data Source =.\\SqlExpress;Initial Catalog = T_Livros; User Id = sa; Pwd=132;";


        public List<LivrosDomain> Listar()
        {
            List<LivrosDomain> Livros = new List<LivrosDomain>();
            string Query = "SELECT Livros.IdLivros,Livros.NomeLivro,Livros.sinopse,Livros.Validador,Livros.IdGeneros,Livros.IdAutores,livros.DataLançamento,Autores.NomeAutor,Autores.IdAutores,Generos.NomeGenero,Generos.IdGeneros FROM Livros INNER JOIN Autores ON Autores.IdAutores = Livros.IdAutores inner join Generos on Generos.IdGeneros = Livros.IdGeneros;";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        LivrosDomain livro = new LivrosDomain
                        {
                            IdLivro = Convert.ToInt32(sdr["IdLivros"])
                            , NomeLivro = sdr["NomeLivro"].ToString()
                            , Sinopse = sdr["Sinopse"].ToString()
                            , DataLancamento = sdr["DataLançamento"].ToString()
                            , Validador = sdr["Validador"].ToString()
                            , genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGeneros"])
                                , NomeGenero = sdr["NomeGenero"].ToString()
                            }
                            , Autor = new AutoresDomain
                            {
                                IdAutor = Convert.ToInt32(sdr["IdAutores"])
                                , NomeAutor = sdr["NomeAutor"].ToString()
                            }
                        };
                        Livros.Add(livro);
                    
                    };

                }
            }
        
                
            

            return Livros ;
        }
        public void Cadastrar(LivrosDomain livrosDomain)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Livros (NomeLivro,sinopse,DataLançamento,Validador,IdGeneros,IdAutores) VALUES (@Nome,@sinopse,@data,@Validador,@IdGenero,@IdAutor)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Nome", livrosDomain.NomeLivro);
                cmd.Parameters.AddWithValue("@Sinopse",livrosDomain.Sinopse );
                cmd.Parameters.AddWithValue("@Data",livrosDomain.DataLancamento );
                cmd.Parameters.AddWithValue("@Validador",livrosDomain.Validador );
                cmd.Parameters.AddWithValue("@IdGenero",livrosDomain.IdGenero );
                cmd.Parameters.AddWithValue("@IdAutor",livrosDomain.IdAutor );
                con.Open();
                cmd.ExecuteNonQuery();

                //Terminar de Cadastrar 



            }
        }














    }
}
