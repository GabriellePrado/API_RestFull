using API_RestFull.Enum;
using API_RestFull.Hypermedia;
using API_RestFull.Hypermedia.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_RestFull.Data.VO
{
    public class ProdutoVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public Categoria TipoProduto { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
