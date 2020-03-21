using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CabBookingEntity;

namespace CabBookingDal
{
    public class LocationRepository : ILocation         //inherits the location interface
    {
        UserContext userContext = new UserContext();
        public IEnumerable<Location> GetLocation()      //displays the location
        {
            IEnumerable<Location> locations = userContext.LocationEntity.ToList();
            return locations;
        }

        public void AddLocation(Location location)   //adds new location
        {
            using (var transaction = userContext.Database.BeginTransaction())   //transaction begins
            {
                try
                {
                    SqlParameter city = new SqlParameter("@CityName", location.CityName);
                    SqlParameter district = new SqlParameter("@DistrictName", location.DistrictName);
                    var data = userContext.Database.ExecuteSqlCommand("Location_Insert @DistrictName, @CityName", district, city);         //calls the insert stored procedure
                    transaction.Commit();       //commits the transaction
                }
                catch(System.Exception)
                {
                    transaction.Rollback();   //rolls back the changes if exception occurs
                }
            }
        }
        public Location GetlocationById(int locationId)     //gets the location 
        {
            return userContext.LocationEntity.Single(id => id.LocationId == locationId);
        }
        
        public void UpdateChanges(Location location)        //updates the edited changes
        {
            using (var transaction = userContext.Database.BeginTransaction())
            {
                try
                {
                    //userContext.Entry(location).State = EntityState.Modified;        //previous method
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

        public void DeleteLocation(int locationId)     //deletes the corresponding location
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
    }
}
