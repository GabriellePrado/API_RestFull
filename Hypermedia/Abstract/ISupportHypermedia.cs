using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.Hypermedia.Abstract
{
   public interface ISupportHypermedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
