using CabBookingEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBookingDal
{
    public class UserContext : DbContext
    {
        public UserContext() :base("UserContext")
        {
              
        }
        public DbSet<User> UserEntity { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Location> LocationEntity { get; set; }
        public DbSet<Cab> CabEntity { get; set; }
        public DbSet<CabType> CabType { get; set; }
        public DbSet<Area> Area { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.MailId).IsUnique();       
            modelBuilder.Entity<Location>().MapToStoredProcedures();
            modelBuilder.Entity<Area>().MapToStoredProcedures();
        }
    }
}
