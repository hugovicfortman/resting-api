using Microsoft.EntityFrameworkCore;
using RESTing.BusinessEntities;
using System;

namespace RESTing.DataAccess.DataContext
{
    public class RESTingContext : DbContext
    {
        public RESTingContext(DbContextOptions options) :
            base(options)
        {

        }

        public DbSet<Auditorium> Auditoria { get; set; }
        public DbSet<Lounge> Lounges { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
