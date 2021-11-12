using API_Calculadora.Data;
using API_Calculadora.Model;
using System.Linq;

namespace API_Rest_Curso.Data
{
    public class PopulaBanco
    {
        MySQLContext _context;
        public PopulaBanco(MySQLContext context)
        {
            _context = context;
        }

        public void PopulaBaseDados()
        {
            if (_context.Persons.Any())
            {
                return;//DB ja populado
            }

            Person p1 = new Person("Gabrielle", "Prado", "gabrielle@gmail.com", 'F');
            Person p2 = new Person("Antonio", "Prado", "antony@gmail.com", 'M');
            Person p3 = new Person("Henrique", "Silva", "HH@gmail.com", 'M');
            Person p4 = new Person("Bob", "Zum", "bob@gmail.com", 'M');
            Person p5 = new Person("Juju", "marcola", "juju@gmail.com", 'F');
            Person p6 = new Person("Jorel", "jj", "jorel@gmail.com", 'M');

            _context.Persons.AddRange(p1, p2, p3, p4, p5, p6);

            _context.SaveChanges();
        }
    }
}
