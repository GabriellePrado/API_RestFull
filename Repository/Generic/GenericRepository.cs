using API_RestFull.Exceptions;
using API_RestFull.DB;
using API_RestFull.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using API_RestFull.Model.Base;

namespace API_RestFull.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ConexaoSql _context;

        private DbSet<T> dataset;

        public GenericRepository(ConexaoSql context)
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
                    _context.Remove(atualizacao);
                    _context.SaveChanges();
                }
                catch (_Exceptions e)
                {
                    throw new _Exceptions("Erro ao deletar" + e.Message);
                }
        }

        public List<T> FindAll()
        {
           var teste = dataset.ToList();
            return teste;
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
            var atualizacao = _context.Clientes.SingleOrDefault(p => p.Id.Equals(item.Id));
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

        public bool ValidaCliente(int id)
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
