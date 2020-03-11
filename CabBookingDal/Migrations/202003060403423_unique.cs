namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Locations", "CityName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locations", new[] { "CityName" });
        }
    }
}
