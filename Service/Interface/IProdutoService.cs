using API_RestFull.Data.VO;
using System.Collections.Generic;

namespace API_RestFull.Service.Interface
{
    public class IProdutoService
    {
        ProdutoVO Create(ProdutoVO produto);
        ProdutoVO FindByID(int id);
        ProdutoVO Update(ProdutoVO produto);
        List<ProdutoVO> FindAll();
        void Delete(int id);
    }
}
