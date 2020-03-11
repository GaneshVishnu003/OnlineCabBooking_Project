namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CabDetails", "CarType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CabDetails", "CarType", c => c.String(nullable: false));
        }
    }
}
