
using API_RestFull.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RestFull.DB
{
    public class ConexaoSql : DbContext
    {
        public ConexaoSql()
        {
        }
        public ConexaoSql(DbContextOptions<ConexaoSql> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
