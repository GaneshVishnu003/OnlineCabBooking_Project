using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CabBookingEntity;

namespace CabBookingDal
{
    public class LocationRepository
    {
        UserContext userContext = new UserContext();
        public IEnumerable<Location> GetLocation()//display
        {
            IEnumerable<Location> locations = userContext.LocationEntity.ToList();
            return locations;
        }
        //area
        public IEnumerable<Area> GetArea(int id)
        {
            return userContext.Area.Where(value => value.LocationId == id).ToList();
        }
        public IEnumerable<Area> DropOff(int id)
        {
            int locationId = userContext.Area.Where(value => value.AreaId == id).FirstOrDefault().LocationId;
            return userContext.Area.Where(value=>value.AreaId != id && value.LocationId==locationId).ToList();
        }

        public void AddLocation(Location location)   //new location
        {
            using (var transaction = userContext.Database.BeginTransaction())
            {
                try
                {
                    SqlParameter city = new SqlParameter("@CityName", location.CityName);
                    SqlParameter district = new SqlParameter("@DistrictName", location.DistrictName);
                    var data = userContext.Database.ExecuteSqlCommand("Location_Insert @DistrictName, @CityName", district, city);
                    //userContext.LocationEntity.Add(location);    //previous create
                    //userContext.SaveChanges();
                    transaction.Commit();
                }
                catch(System.Exception)
                {
                    transaction.Rollback();
                }
            }
        }
        public Location GetlocationById(int locationId)//edit
        {
            return userContext.LocationEntity.Single(id => id.LocationId == locationId);
        }
        public void DeleteLocation(int locationId)//delete
        {
            using (var transaction = userContext.Database.BeginTransaction())
            {
                try
                {
                    SqlParameter id = new SqlParameter("@LocationId", locationId);
                    var data = userContext.Database.ExecuteSqlCommand("Location_Delete @LocationId", id);
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                }
            }
        }
        public void UpdateChanges(Location location)//update
        {
            using (var transaction = userContext.Database.BeginTransaction())
            {
                try
                {
                    //userContext.Entry(location).State = EntityState.Modified;
                    SqlParameter id = new SqlParameter("@LocationId", location.LocationId);
                    SqlParameter city = new SqlParameter("@CityName", location.CityName);
                    SqlParameter district = new SqlParameter("@DistrictName", location.DistrictName);
                    var datainfo = userContext.Database.ExecuteSqlCommand("Location_Update @LocationId,@DistrictName, @CityName", district, city, id);
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
}
