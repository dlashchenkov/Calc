using Calc.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Data
{
    public class CalcDBContext : DbContext
    {
        public DbSet<SumLog> SumLogs2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("SQL server isn't configured");
            }
        }

        public CalcDBContext() { }

        public CalcDBContext(DbContextOptions<CalcDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
