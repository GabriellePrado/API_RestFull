using API_RestFull.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_RestFull.Model
{
    [Table("dbCliente")]
    public class Cliente : BaseEntity
    {
        //Cliente é a classe para cadastro do cliente
        [Column("Cpf")]
        public string Cpf { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Sobrenome")]
        public string Sobrenome { get; set; }
        [Column("Email")]
        public string Email { get; set; }

        public Cliente()
        {
        }

        public Cliente(string _cpf, string _nome, string _sobrenome, string _email)
        {
            Cpf = _cpf;
            Nome = _nome;
            Sobrenome = _sobrenome;
            Email = _email;
        }
    }
}

  