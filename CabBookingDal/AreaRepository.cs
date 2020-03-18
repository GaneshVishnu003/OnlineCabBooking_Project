using CabBookingEntity;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace CabBookingDal
{
    public class AreaRepository
    {
        public void AddArea(Area area)   //new location
        {
            using (UserContext userContext = new UserContext())
            {
                using (var transaction = userContext.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter locationId = new SqlParameter("@LocationId", area.LocationId);
                        SqlParameter areaName = new SqlParameter("@AreaName", area.AreaName);
                        var data = userContext.Database.ExecuteSqlCommand("Area_Insert @LocationId, @AreaName", locationId, areaName);
                        //userContext.LocationEntity.Add(location);    //previous create
                        //userContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public int DeleteLocation(int areaId)
        {
            using(UserContext userContext =new UserContext())
            {
                using (var transaction = userContext.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter id = new SqlParameter("@AreaId", areaId);
                        var data = userContext.Database.ExecuteSqlCommand("Area_Delete @AreaId", id);
                        transaction.Commit();
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();
                    }
                    int locationId= userContext.Area.Where(value => value.AreaId == areaId).FirstOrDefault().LocationId;
                    return locationId;
                }
            }
        }

        public void UpdateChanges(Area area)
        {
            using (UserContext userContext = new UserContext())
            {
                using (var transaction = userContext.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter areaId = new SqlParameter("@AreaId", area.AreaId);
                        SqlParameter areaName = new SqlParameter("@AreaName", area.AreaName);
                        SqlParameter locationId = new SqlParameter("@LocationId", area.LocationId);
                        var datainfo = userContext.Database.ExecuteSqlCommand("Area_Update  @AreaId,@LocationId,@AreaName", areaId,locationId, areaName);
                        //userContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public Area GetAreaById(int areaId)
        {
            using(UserContext userContext = new UserContext())
            {
                return userContext.Area.Single(id => id.AreaId == areaId);
            }
        }
    }
}
