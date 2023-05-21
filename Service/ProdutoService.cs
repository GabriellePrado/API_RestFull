using API_RestFull.Data.Converter.Implementation;
using API_RestFull.Data.VO;
using API_RestFull.Model;
using API_RestFull.Repository.Generic;
using API_RestFull.Service.Interface;
using System.Collections.Generic;

namespace API_RestFull.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepository<Produto> _repository;
        private readonly ProdutoConverter _converter;

        public ProdutoService(IRepository<Produto> repository)
        {
            _repository = repository;
            _converter = new ProdutoConverter();
        }
        public ProdutoVO Create(ProdutoVO Produto)
        {
            var ProdutoEntity = _converter.Parse(Produto);
            ProdutoEntity = _repository.Create(ProdutoEntity);
            return _converter.Parse(ProdutoEntity);
        }

        public ProdutoVO Update(ProdutoVO Produto)
        {
            var ProdutoEntity = _converter.Parse(Produto);
            ProdutoEntity = _repository.Update(ProdutoEntity);
            return _converter.Parse(ProdutoEntity);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ProdutoVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());

        }
        public ProdutoVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

    }
}
