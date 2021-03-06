﻿using CabBookingEntity;
using System.Collections.Generic;

namespace CabBookingDal
{
    public interface ILocation      //location interface
    {
        IEnumerable<Location> GetLocation();
        void AddLocation(Location location);
        Location GetlocationById(int locationId);
        void UpdateChanges(Location location);
        void DeleteLocation(int id);
    }
}
