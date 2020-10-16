namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "DistrictName", c => c.String(nullable: false, maxLength: 30));
            AlterStoredProcedure(
                "dbo.Location_Insert",
                p => new
                    {
                        CityName = p.String(maxLength: 20),
                        DistrictName = p.String(maxLength: 30),
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
            
            AlterStoredProcedure(
                "dbo.Location_Update",
                p => new
                    {
                        LocationId = p.Int(),
                        CityName = p.String(maxLength: 20),
                        DistrictName = p.String(maxLength: 30),
                    },
                body:
                    @"UPDATE [dbo].[Locations]
                      SET [CityName] = @CityName, [DistrictName] = @DistrictName
                      WHERE ([LocationId] = @LocationId)"
            );
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "DistrictName", c => c.String(nullable: false));
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
