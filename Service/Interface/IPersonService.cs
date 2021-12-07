using API_RestFull.Data.VO;
using API_RestFull.Model;
using System.Collections.Generic;

namespace API_RestFull.Service.Interface
{
    public interface IPersonService
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(int id);
        PersonVO Update(PersonVO person);
        List<PersonVO> FindAll();
        void Delete(int id);

    }
}
