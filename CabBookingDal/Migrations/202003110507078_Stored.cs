namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stored : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Location_Insert",
                p => new
                    {
                        CityName = p.String(maxLength: 20),
                        DistrictName = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Locations]([CityName], [DistrictName])
                      VALUES (@CityName, @DistrictName)
                      
                      DECLARE @LocationId int
                      SELECT @LocationId = [LocationId]
                      FROM [dbo].[Locations]
                      WHERE @@ROWCOUNT > 0 AND [LocationId] = scope_identity()
                      
                      SELECT t0.[LocationId]
                      FROM [dbo].[Locations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[LocationId] = @LocationId"
            );
            
            CreateStoredProcedure(
                "dbo.Location_Update",
                p => new
                    {
                        LocationId = p.Int(),
                        CityName = p.String(maxLength: 20),
                        DistrictName = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Locations]
                      SET [CityName] = @CityName, [DistrictName] = @DistrictName
                      WHERE ([LocationId] = @LocationId)"
            );
            
            CreateStoredProcedure(
                "dbo.Location_Delete",
                p => new
                    {
                        LocationId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Locations]
                      WHERE ([LocationId] = @LocationId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Location_Delete");
            DropStoredProcedure("dbo.Location_Update");
            DropStoredProcedure("dbo.Location_Insert");
        }
    }
}
