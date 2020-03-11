namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CabDetails",
                c => new
                    {
                        CabId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CabNumber = c.String(nullable: false, maxLength: 10),
                        TypeId = c.Int(nullable: false),
                        LicenceNumber = c.String(nullable: false, maxLength: 15),
                        CarType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CabId)
                .ForeignKey("dbo.CabTypes", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => new { t.CabNumber, t.LicenceNumber }, name: "OfficialIds")
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.CabTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
            CreateIndex("dbo.Locations", "CityName", name: "OfficialIds");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CabDetails", "UserId", "dbo.User");
            DropForeignKey("dbo.CabDetails", "TypeId", "dbo.CabTypes");
            DropIndex("dbo.Locations", "OfficialIds");
            DropIndex("dbo.CabDetails", new[] { "TypeId" });
            DropIndex("dbo.CabDetails", "OfficialIds");
            DropIndex("dbo.CabDetails", new[] { "UserId" });
            DropTable("dbo.CabTypes");
            DropTable("dbo.CabDetails");
        }
    }
}
