using System.Collections.Generic;
using System.Linq;
using CabBookingEntity;

namespace CabBookingDal
{
    public class LocationRepository : ILocation         //inherits the location interface
    {

        //returns the location for display
        public IEnumerable<Location> GetLocation()      
        {
            using (UserContext userContext = new UserContext())
            {
                IEnumerable<Location> locations = userContext.LocationEntities.ToList();
                return locations;
            }
        }

        //adds new location
        public void AddLocation(Location location)   
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.LocationEntities.Add(location);
                userContext.SaveChanges();
            }
        }

        //gets the location 
        public Location GetlocationById(int locationId)     
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.LocationEntities.Single(id => id.LocationId == locationId);
            }
        }

        //updates the edited changes
        public void UpdateChanges(Location location)        
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.Entry(location).State = System.Data.Entity.EntityState.Modified;
                userContext.SaveChanges();
            }
        }

        //deletes the corresponding location
        public void DeleteLocation(int locationId)     
        {
            using (UserContext userContext = new UserContext())
            {
                Location location = GetlocationById(locationId);
                userContext.LocationEntities.Attach(location);         //needs attach since different context object
                userContext.LocationEntities.Remove(location);
                userContext.SaveChanges();
            }
        }
    }
}
