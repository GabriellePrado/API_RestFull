using API_RestFull.Data.VO;
using System.Collections.Generic;

namespace API_RestFull.Service.Interface
{
    public interface ISacolaService
    {
        SacolaVO Create(SacolaVO Sacola);
        SacolaVO FindByID(int id);
        SacolaVO Update(SacolaVO Sacola);
        List<SacolaVO> FindAll();
        void Delete(int id);
    }
}
