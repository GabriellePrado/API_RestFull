using API_Calculadora.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Calculadora.Service.Interface
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindByID(int id);
        Person Update(Person person);
        List<Person> FindAll();
        void Delete(int id);

    }
}
