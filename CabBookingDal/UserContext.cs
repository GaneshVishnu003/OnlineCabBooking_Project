using CabBookingEntity;
using System.Data.Entity;

namespace CabBookingDal
{
    public class UserContext : DbContext
    {
        public UserContext() :base("UserContext")
        {
              
        }
        public DbSet<User> UserEntities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Location> LocationEntities { get; set; }
        public DbSet<Cab> CabEntities { get; set; }
        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.MailId).IsUnique();       
            modelBuilder.Entity<Location>().MapToStoredProcedures();
            modelBuilder.Entity<Area>().MapToStoredProcedures();
        }
    }
}
