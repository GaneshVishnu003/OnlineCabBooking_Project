﻿namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CabDetails", "RequestStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CabDetails", "RequestStatus");
        }
    }
}
