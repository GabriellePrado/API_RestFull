using API_RestFull.Data.VO;
using API_RestFull.Model;
using System.Collections.Generic;

namespace API_RestFull.Service.Interface
{
    public interface IClienteService
    {
        ClienteVO Create(ClienteVO Cliente);
        ClienteVO FindByID(int id);
        ClienteVO Update(ClienteVO Cliente);
        List<ClienteVO> FindAll();
        void Delete(int id);

    }
}
