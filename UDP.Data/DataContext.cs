using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDP.Data
{
    public class DataContext: DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options)
                : base(options)
        {
        }
        public DbSet<DataModel> DataModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=udpdata;Trusted_Connection=True;TrustServerCertificate = True;");
            //Data Source=localhost;Initial Catalog =udpdata;Integrated Security = True;Encrypt = True;TrustServerCertificate = True;User Instance = False
        }
    }
}
