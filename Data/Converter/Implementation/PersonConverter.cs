using API_RestFull.Data.Converter.Contract;
using API_RestFull.Data.VO;
using API_RestFull.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.Data.Converter.Implementation
{
    public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO>
    {
        public int Id { get; private set; }

        public Person Parse(PersonVO origem)
        {
            if (origem == null) return null;
            return new Person {
                Id = origem.Id,
                Nome = origem.Nome,
                Sobrenome = origem.Sobrenome,
                Email = origem.Email,
                Genero = origem.Genero
            };
        }

        public PersonVO Parse(Person origem)
        {
            if (origem == null) return null;
            return new PersonVO
            {
                Id = origem.Id,
                Nome = origem.Nome,
                Sobrenome = origem.Sobrenome,
                Email = origem.Email,
                Genero = origem.Genero
            };
        }
        public List<Person> Parse(List<PersonVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
