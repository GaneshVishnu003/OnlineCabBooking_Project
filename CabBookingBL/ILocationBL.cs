using CabBookingEntity;
using System.Collections.Generic;

namespace CabBookingBL
{
    public interface ILocationBL
    {
        IEnumerable<Location> GetLocation();
        void AddLocation(Location location);
        Location GetlocationById(int locationId);
        void UpdateChanges(Location location);
        void DeleteLocation(int id);
    }
}
