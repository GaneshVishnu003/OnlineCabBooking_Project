using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabBookingEntity;

namespace CabBookingDal
{
    public class LocationRepository
    {
        UserContext userContext = new UserContext();
        public IEnumerable<Location> GetLocation()
        {
            IEnumerable<Location> locations = userContext.LocationEntity.ToList();
            return locations;
        }
        public Location GetlocationById(int locationId)
        {
            //UserContext userContext = new UserContext();
            return userContext.LocationEntity.Single(id => id.LocationId == locationId);
        }
        public void DeleteLocation(int locationId)
        {
            Location location = userContext.LocationEntity.Single(id => id.LocationId == locationId);
            userContext.LocationEntity.Remove(location);
            userContext.SaveChanges();
        }
        public void UpdateChanges(Location location)
        {
            try
            {
                userContext.Entry(location).State = EntityState.Modified;
                userContext.SaveChanges();
            }
            catch(Exception)
            {

            }
        }
        //public static List<Location> list = new List<Location>();
        //static LocationRepository()
        //{
        //    list.Add(new Location { LocationId = 10, LocationName = "Erode" });
        //    list.Add(new Location { LocationId = 11, LocationName = "Salem" });
        //    list.Add(new Location { LocationId = 12, LocationName = "Trichy" });
        //}
        //public static IEnumerable<Location> GetLocation()
        //{
        //    return list;
        //}
        //public static void Add(Location cab)
        //{
        //    list.Add(cab);
        //}
        //public static void Delete(int locationId)
        //{
        //    Location cab = GetLocationById(locationId);
        //    if (cab != null)
        //        list.Remove(cab);
        //}
        //public static void Update(Location cab)
        //{
        //    Location locationEntity = list.Find(id => id.LocationId == cab.LocationId);
        //    locationEntity.LocationName = cab.LocationName;
        //}
        //public static Location GetLocationById(int locationId)
        //{
        //    return list.Find(id => id.LocationId == locationId);
        //}
    }
}
