using API_RestFull.Data.Converter.Implementation;
using API_RestFull.Data.VO;
using API_RestFull.Model;
using API_RestFull.Repository.Generic;
using API_RestFull.Service.Interface;
using System.Collections.Generic;

namespace API_RestFull.Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());

        }
        public PersonVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        /*public async Task<Colaborador> ExistsByCpfAsync(string colaboradorCpf)
        {
            try
            {
                string sql = $"{baseSql} AND cpf = @Cpf";

                var colaboradors = await _dbConnector.QueryAsync<Colaborador>(sql, new { Cpf = colaboradorCpf });

                return colaboradors.FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        */
    }
}
