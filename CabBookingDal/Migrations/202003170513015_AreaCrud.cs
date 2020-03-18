namespace CabBookingDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AreaCrud : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Area_Insert",
                p => new
                    {
                        LocationId = p.Int(),
                        AreaName = p.String(maxLength: 30),
                    },
                body:
                    @"INSERT [dbo].[Areas]([LocationId], [AreaName])
                      VALUES (@LocationId, @AreaName)
                      
                      DECLARE @AreaId int
                      SELECT @AreaId = [AreaId]
                      FROM [dbo].[Areas]
                      WHERE @@ROWCOUNT > 0 AND [AreaId] = scope_identity()
                      
                      SELECT t0.[AreaId]
                      FROM [dbo].[Areas] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[AreaId] = @AreaId"
            );
            
            CreateStoredProcedure(
                "dbo.Area_Update",
                p => new
                    {
                        AreaId = p.Int(),
                        LocationId = p.Int(),
                        AreaName = p.String(maxLength: 30),
                    },
                body:
                    @"UPDATE [dbo].[Areas]
                      SET [LocationId] = @LocationId, [AreaName] = @AreaName
                      WHERE ([AreaId] = @AreaId)"
            );
            
            CreateStoredProcedure(
                "dbo.Area_Delete",
                p => new
                    {
                        AreaId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Areas]
                      WHERE ([AreaId] = @AreaId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Area_Delete");
            DropStoredProcedure("dbo.Area_Update");
            DropStoredProcedure("dbo.Area_Insert");
        }
    }
}
