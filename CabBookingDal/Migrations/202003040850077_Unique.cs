namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unique : DbMigration
    {
        public override void Up()
        { 
            RenameTable(name: "dbo.Roles", newName: "Role");
            RenameTable(name: "dbo.Users", newName: "User");
            CreateIndex("dbo.Locations", "CityName", unique: true);
            CreateIndex("dbo.User", "MailId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "MailId" });
            DropIndex("dbo.Locations", new[] { "CityName" });
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.Role", newName: "Roles");
        }
    }
}
