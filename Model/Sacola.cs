using API_RestFull.Model.Base;
using System.Collections.Generic;

namespace API_RestFull.Model
{
    public class Sacola : BaseEntity
    {
        
        public List<Produto> ItensSacola { get; set; }
        public double ValorTotal { get; set; }
    }
}
