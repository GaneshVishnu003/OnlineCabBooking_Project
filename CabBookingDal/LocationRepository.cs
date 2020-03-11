using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void AddLocation(Location location)   //new location
        {
            SqlParameter city = new SqlParameter("@CityName", location.CityName);
            SqlParameter district = new SqlParameter("@DistrictName", location.DistrictName);
            var data = userContext.Database.ExecuteSqlCommand("Location_Insert @DistrictName, @CityName",district,city);
            //userContext.LocationEntity.Add(location);
            userContext.SaveChanges();
        }
        public Location GetlocationById(int locationId)//edit
        {
            return userContext.LocationEntity.Single(id => id.LocationId == locationId);
        }
        public void DeleteLocation(int locationId)//delete
        {
            SqlParameter id = new SqlParameter("@LocationId", locationId);
            var data = userContext.Database.ExecuteSqlCommand("Location_Delete @LocationId", id);
            //Location location = userContext.LocationEntity.Single(id => id.LocationId == locationId);
            //userContext.LocationEntity.Remove(location);
            userContext.SaveChanges();
        }
        public void UpdateChanges(Location location)//update
        {
            //try
            {
                //userContext.Entry(location).State = EntityState.Modified;
                SqlParameter id = new SqlParameter("@LocationId", location.LocationId);
                SqlParameter city = new SqlParameter("@CityName", location.CityName);
                SqlParameter district = new SqlParameter("@DistrictName", location.DistrictName);
                var datainfo = userContext.Database.ExecuteSqlCommand("Location_Update @LocationId,@DistrictName, @CityName", district, city,id);
                userContext.SaveChanges();
            }
            //catch(Exception)
            {

            }
        }
    }
}
