using CabBookingEntity;
using CabBookingDal;
using System.Collections.Generic;

namespace CabBookingBL
{
    public class LocationBL
    {
        LocationRepository locationRepository = new LocationRepository();
        public IEnumerable<Location> GetLocation()
        {
            return locationRepository.GetLocation();
        }

       

        public void AddLocation(Location location)
        {
            locationRepository.AddLocation(location);
        }

        public Location GetlocationById(int id)
        {
            return locationRepository.GetlocationById(id);
        }

        public void UpdateChanges(Location location)
        {
            locationRepository.UpdateChanges(location);
        }

        public void DeleteLocation(int id)
        {
            locationRepository.DeleteLocation(id);
        }

        //area methods
        public IEnumerable<Area> GetArea(int id)
        {
            return locationRepository.GetArea(id);
        }

        public IEnumerable<Area> DropOff(int id)
        {
            //int pickupId = area.AreaId;
            return locationRepository.DropOff(id);
        }
    }
}
