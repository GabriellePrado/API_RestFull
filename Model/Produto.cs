using API_RestFull.Enum;
using API_RestFull.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_RestFull.Model
{
    [Table("dbProduto")]
    public class Produto : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("Valor")]
        public double Valor { get; set; }
        [Column("TipoProduto")]
        public Categoria TipoProduto { get; set; }

        public Produto()
        {
        }

        public Produto(string _nome, string _descricao, double _valor, Categoria _tipoProduto)
        {
            Nome = _nome;
            Descricao = _descricao;
            Valor = _valor;
            TipoProduto = _tipoProduto;
        }
    }
}
