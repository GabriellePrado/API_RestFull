using API_Calculadora.Data;
using API_Calculadora.Exceptions;
using API_RestFull.Model.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_RestFull.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (_Exceptions e)
            {
                throw new _Exceptions("Erro ao criar" + e.Message);
            }
        }

        public void Delete(int id)
        {
            var atualizacao = dataset.SingleOrDefault(p => p.Id.Equals(id));
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

        public List<T> FindAll()
        {
            return dataset.ToList();

        }
        public T FindByID(int id)
        {
            try
            {
                return dataset.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (_Exceptions e)
            {
                throw new _Exceptions("Erro ao procurar usuario" + e.Message);
            }
        }

        public T Update(T item)
        {
            var atualizacao = _context.Persons.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (atualizacao != null)
            {
                try
                {
                    _context.Entry(atualizacao).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (_Exceptions e)
                {
                    throw new _Exceptions("Erro ao atualizar" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }

        public bool ValidaPerson(int id)
        {
            bool validacao = dataset     .Any(p => p.Id.Equals(id));
            if (validacao == true)
            {
                return true;
            }
            return false;
        }
    }
}
