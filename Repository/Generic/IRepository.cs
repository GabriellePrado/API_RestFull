using API_RestFull.Model;
using API_RestFull.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(int id);
        T Update(T item);
        List<T> FindAll();
        void Delete(int id);
    }
}
