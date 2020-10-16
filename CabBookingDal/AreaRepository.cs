using CabBookingEntity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CabBookingDal
{
    public class AreaRepository : IArea
    {
        //Adds new area
        public void AddArea(Area area)   
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
                        throw;
                    }
                }
            }
        }

        //gets the area rows with corresponding location id
        public IEnumerable<Area> GetArea(int id)        
        {
            using (UserContext userContext = new UserContext())             //context object creation
            {
                return userContext.Areas.Where(value => value.LocationId == id).ToList();    //returns area object
            }
        }

        //gets the area rows except the pickup area
        public IEnumerable<Area> DropOff(int id)        
        {
            using (UserContext userContext = new UserContext())             //context object creation
            {
                int locationId = userContext.Areas.Where(value => value.AreaId == id).FirstOrDefault().LocationId;       //gets the location of pickup area
                return userContext.Areas.Where(value => value.AreaId != id && value.LocationId == locationId).ToList();      //return remaining areas for drop off
            }
        }

        //gets the area with the id
        public Area GetAreaById(int areaId)         
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.Areas.Single(id => id.AreaId == areaId);         //returns the area 
            }
        }

        //updates the edited
        public void UpdateChanges(Area area)            
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
                        throw;
                    }
                }
            }
        }

        //gets the location by the area id
        public int GetLocationByArea(int id)          
        {
            using (UserContext userContext = new UserContext())
            {
                var obj = userContext.Areas.Where(value => value.AreaId == id).SingleOrDefault();
                return obj.LocationId;
            }
        }

        //deletes the area
        public void DeleteArea(int areaId)          
        {
            using (UserContext userContext = new UserContext())
            {
                Area area = GetAreaById(areaId);
                userContext.Areas.Attach(area);
                userContext.Areas.Remove(area);
                userContext.SaveChanges();
            }
        }
    }
}
