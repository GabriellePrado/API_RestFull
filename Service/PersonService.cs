using API_Calculadora.Data;
using API_Calculadora.Exceptions;
using API_Calculadora.Model;
using API_Calculadora.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Calculadora.Service
{
    public class PersonService : IPersonService
    {
        private MySQLContext _context;

        public PersonService(MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (_Exceptions e)
            {
                throw new _Exceptions("Erro ao criar" + e.Message);
            }
            return person;
        }

        public void Delete(int id)
        {
            var atualizacao = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (atualizacao != null)
                try
            {
                _context.Remove(atualizacao.Id);
                _context.SaveChanges();
            }
            catch (_Exceptions e)
            {
                throw new _Exceptions("Erro ao deletar" + e.Message);
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();

        }
        public Person FindByID(int id)
        {
            try
            {
                return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (_Exceptions e)
            {
                throw new _Exceptions("Erro ao procurar usuario" + e.Message);
            }
        }

        public Person Update(Person person)
        {
            var atualizacao = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (atualizacao != null)
                try
                {
                    _context.Entry(atualizacao).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                //if (!ValidaPerson(person.Id))
                //{
                //    _context.Update(person);
                //    _context.SaveChanges();
            }
            catch (_Exceptions e)
            {
                throw new _Exceptions("Erro ao atualizar" + e.Message);
            }
            return person;
        }

        public bool ValidaPerson(int id)
        {
            bool validacao = _context.Persons.Any(p => p.Id.Equals(id));
            if (validacao == true)
            {
                return true;
            }
            return false;
        }
    }
}
