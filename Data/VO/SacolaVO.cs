using API_RestFull.Model;
using System.Collections.Generic;

namespace API_RestFull.Data.VO
{
    public class SacolaVO
    {
        public int Id { get; set; }
        public List<Produto> ItensSacola { get; set; }
        public double ValorTotal { get; set; }
    }
}
