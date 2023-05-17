
using API_RestFull.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.DB
{
    public class ConexaoMySql : DbContext
    {
        public ConexaoMySql()
        {
        }
        public ConexaoMySql(DbContextOptions<ConexaoMySql> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}
