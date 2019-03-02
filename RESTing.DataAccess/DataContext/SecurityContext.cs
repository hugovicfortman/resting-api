using Microsoft.EntityFrameworkCore;
using RESTing.BusinessEntities.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTing.DataAccess.DataContext
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions options) :
            base(options)
        {

        }

        public DbSet<APIAccessLog> AccessLogs { get; set; }
        public DbSet<APIManagedKey> APIManagedKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
