using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.Data.Converter.Contract
{
    public interface IParse <Origem, Destino>
    {
        
        Destino Parse(Origem origem);
        List<Destino> Parse(List<Origem> origem);
    }
}
