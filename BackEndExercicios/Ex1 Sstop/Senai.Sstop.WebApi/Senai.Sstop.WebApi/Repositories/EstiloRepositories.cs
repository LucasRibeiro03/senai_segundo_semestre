using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;

namespace Senai.Sstop.WebApi.Controllers
{

    
        public class EstiloRepository
        {
            private string stringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";

            public List<EstiloDomain> Listar()
            {
                //Buscar os dados do banco de dados

                List<EstiloDomain> estilos = new List<EstiloDomain>();
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
                            EstiloDomain estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                Nome = sdr["Nome"].ToString()

                            };
                            estilos.Add(estilo);
                        }

                    }
                }

                //Execitar o select
                //Retornar as informacoes
                return  estilos;
            }


        }
        
    }
