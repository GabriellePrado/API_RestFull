using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.Data.VO
{
    public class PersonVO
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
       
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public char Genero { get; set; }
    }
}
