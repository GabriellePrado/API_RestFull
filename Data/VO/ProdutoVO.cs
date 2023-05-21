using API_RestFull.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_RestFull.Data.VO
{
    public class ProdutoVO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public Categoria TipoProduto { get; set; }
    }
}
