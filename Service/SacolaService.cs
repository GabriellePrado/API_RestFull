using API_RestFull.Data.Converter.Implementation;
using API_RestFull.Data.VO;
using API_RestFull.Model;
using API_RestFull.Repository.Generic;
using API_RestFull.Service.Interface;
using System.Collections.Generic;

namespace API_RestFull.Service
{
    public class SacolaService : ISacolaService
    {
        private readonly IRepository<Sacola> _repository;
        private readonly SacolaConverter _converter;

        public SacolaService(IRepository<Sacola> repository, SacolaConverter converter)
        {
            _repository = repository;
            _converter = converter;
        }
        public SacolaVO Create(SacolaVO sacola)
        {
            var sacolaEntity = _converter.Parse(sacola);
            sacolaEntity = _repository.Create(sacolaEntity);
            return _converter.Parse(sacolaEntity);
        }
        public SacolaVO Update(SacolaVO sacola)
        {
            var sacolaEntity = _converter.Parse(sacola);
            sacolaEntity = _repository.Update(sacolaEntity);
            return _converter.Parse(sacolaEntity);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<SacolaVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());

        }
        public SacolaVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }



    }
}
