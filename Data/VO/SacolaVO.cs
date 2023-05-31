using API_RestFull.Hypermedia;
using API_RestFull.Hypermedia.Abstract;
using API_RestFull.Model;
using System.Collections.Generic;

namespace API_RestFull.Data.VO
{
    public class SacolaVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public List<Produto> ItensSacola { get; set; }
        public double ValorTotal { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
