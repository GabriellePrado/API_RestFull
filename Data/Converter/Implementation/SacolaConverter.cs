using API_RestFull.Data.Converter.Contract;
using API_RestFull.Data.VO;
using API_RestFull.Model;
using System.Collections.Generic;
using System.Linq;

namespace API_RestFull.Data.Converter.Implementation
{
    public class SacolaConverter : IParse<SacolaVO, Sacola>, IParse<Sacola, SacolaVO>
    {
        public int Id { get; private set; }

        public Sacola Parse(SacolaVO origem)
        {
            if (origem == null) return null;
            return new Sacola
            {
                Id = origem.Id,
                ItensSacola = origem.ItensSacola,
                ValorTotal = origem.ValorTotal
            };
        }

        public SacolaVO Parse(Sacola origem)
        {
            if (origem == null) return null;
            return new SacolaVO
            {
                Id = origem.Id,
                ItensSacola = origem.ItensSacola,
                ValorTotal = origem.ValorTotal
            };
        }
        public List<Sacola> Parse(List<SacolaVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<SacolaVO> Parse(List<Sacola> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
