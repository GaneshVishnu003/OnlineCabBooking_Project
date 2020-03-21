using CabBookingEntity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CabBookingDal
{
    public class AreaRepository : IArea
    {
        public void AddArea(Area area)   //Adds new area
        {
            using (UserContext userContext = new UserContext())         //context object creation
            {
                using (var transaction = userContext.Database.BeginTransaction())       //start of transaction
                {
                    try
                    {
                        SqlParameter locationId = new SqlParameter("@LocationId", area.LocationId);   //value passing for location id parameter
                        SqlParameter areaName = new SqlParameter("@AreaName", area.AreaName);       //value passing for area name parameter
                        var data = userContext.Database.ExecuteSqlCommand("Area_Insert @LocationId, @AreaName", locationId, areaName);      //passing to stored procedure
                        transaction.Commit();           //transaction commit for updation in database
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();         //changes rolls back if exception occured
                    }
                }
            }
        }

        public IEnumerable<Area> GetArea(int id)        //gets the area rows with corresponding location id
        {
            using (UserContext userContext = new UserContext())             //context object creation
            {
                return userContext.Area.Where(value => value.LocationId == id).ToList();    //returns area object
            }
        }
        public IEnumerable<Area> DropOff(int id)        //gets the area rows except the pickup area
        {
            using (UserContext userContext = new UserContext())             //context object creation
            {
                int locationId = userContext.Area.Where(value => value.AreaId == id).FirstOrDefault().LocationId;       //gets the location of pickup area
                return userContext.Area.Where(value => value.AreaId != id && value.LocationId == locationId).ToList();      //return remaining areas for drop off
            }
        }

        public Area GetAreaById(int areaId)         //gets the area with the id
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.Area.Single(id => id.AreaId == areaId);         //returns the area 
            }
        }

        public void UpdateChanges(Area area)            //updates the edited
        {
            using (UserContext userContext = new UserContext())         //context object creation
            {
                using (var transaction = userContext.Database.BeginTransaction())       //starts transaction
                {
                    try
                    {
                        SqlParameter areaId = new SqlParameter("@AreaId", area.AreaId);
                        SqlParameter areaName = new SqlParameter("@AreaName", area.AreaName);
                        SqlParameter locationId = new SqlParameter("@LocationId", area.LocationId);
                        var datainfo = userContext.Database.ExecuteSqlCommand("Area_Update  @AreaId,@LocationId,@AreaName", areaId, locationId, areaName);          //stored procedure call
                        transaction.Commit();           //commits the transaction
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();          //changes rolls back if exception occured
                    }
                }
            }
        }

        public int GetLocationByArea(int id)          //gets the location by the area id
        {
            using (UserContext userContext = new UserContext())
            {
                var obj = userContext.Area.Where(value => value.AreaId == id).SingleOrDefault();
                return obj.LocationId;
            }
        }

        public void DeleteArea(int areaId)          //deletes the area
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
                }
            }
        }
    }
}
