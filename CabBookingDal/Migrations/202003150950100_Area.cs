namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Area : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Locations", new[] { "CityName" });
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        AreaName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.AreaId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.AreaName, name: "OfficialIds");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "LocationId", "dbo.Locations");
            DropIndex("dbo.Areas", "OfficialIds");
            DropIndex("dbo.Areas", new[] { "LocationId" });
            DropTable("dbo.Areas");
            CreateIndex("dbo.Locations", "CityName", unique: true);
        }
    }
}
