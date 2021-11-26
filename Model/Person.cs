using API_RestFull.Model.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Calculadora.Model
{
    [Table("pessoas")]
    public class Person : BaseEntity
    {
       
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Sobrenome")]
        public string Sobrenome { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Genero")]
        public char Genero { get; set; }
    
    public Person()
        {
        }
    public Person(string nome, string sobrenome, string email, char genero)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Genero = genero;
        }
    
    
    }
}

  