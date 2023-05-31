using API_RestFull.Hypermedia;
using API_RestFull.Hypermedia.Abstract;
using System.Collections.Generic;

namespace API_RestFull.Data.VO
{
    public class ClienteVO : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
