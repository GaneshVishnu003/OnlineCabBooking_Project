namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DistrictName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "CityName", c => c.String(nullable: false));
            AddColumn("dbo.Locations", "DistrictName", c => c.String(nullable: false));
            DropColumn("dbo.Locations", "LocationName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "LocationName", c => c.String(nullable: false));
            DropColumn("dbo.Locations", "DistrictName");
            DropColumn("dbo.Locations", "CityName");
        }
    }
}
