

using CabBookingEntity;
using System.Collections.Generic;

namespace CabBookingDal
{
    public interface IArea      //area interface
    {
        //methods used by AreaBL and AreaDal
        void AddArea(Area area);
        IEnumerable<Area> GetArea(int id);
        IEnumerable<Area> DropOff(int id);
        Area GetAreaById(int areaId);
        void UpdateChanges(Area area);
        int GetLocationByArea(int id);
        void DeleteArea(int id);
    }
}
