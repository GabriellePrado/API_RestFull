using API_Calculadora.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Calculadora.Data
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
        }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}
