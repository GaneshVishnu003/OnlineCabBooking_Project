namespace CabBookingDal.Migrations
{
    using CabBookingEntity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CabBookingDal.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CabBookingDal.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
    //public class RoleInitializer:DropCreateDatabaseAlways<UserContext>
    //{
    //    protected override void Seed(UserContext context)
    //    {
    //        List<Role> roles = new List<Role>();
    //        roles.Add(new Role() { RoleID = 1, RoleName = "Driver" });
    //        roles.Add(new Role() { RoleID = 2, RoleName = "Customer"});
    //        context.Role.AddRange(roles);
    //        base.Seed(context);
    //    }
    //}
}
