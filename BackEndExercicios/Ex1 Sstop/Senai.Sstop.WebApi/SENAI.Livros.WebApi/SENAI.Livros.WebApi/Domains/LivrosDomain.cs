using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.Livros.WebApi.Domains
{
    public class LivrosDomain
    {
        public int IdLivro { get; set; }
        public string NomeLivro { get; set; }
        public string Sinopse { get; set; }
        public string DataLancamento { get; set; }
        public string Validador { get; set; }
        public int IdGenero { get; set; }
        public int IdAutor { get; set; }
        //tabelas inseridas 
        public GeneroDomain genero { get; set; }
        public AutoresDomain Autor { get; set; }
    }
}
