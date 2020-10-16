using CabBookingEntity;
using CabBookingDal;
using System.Collections.Generic;

namespace CabBookingBL
{
    public class LocationBL : ILocationBL
    {
        ILocation locationRepository = new LocationRepository();    //locationrepository instance for location interface
        public IEnumerable<Location> GetLocation()          //gets the location      
        {
            return locationRepository.GetLocation();
        }

        public void AddLocation(Location location)      //adds new location
        {
            locationRepository.AddLocation(location);
        }

        public Location GetlocationById(int id)             //gets the respective location according to id
        {
            return locationRepository.GetlocationById(id);
        }

        public void UpdateChanges(Location location)        //updates the changes in the location name
        {
            locationRepository.UpdateChanges(location);
        }

        public void DeleteLocation(int id)              //delete the location in the passed id
        {
            locationRepository.DeleteLocation(id);
        }
    }
}
