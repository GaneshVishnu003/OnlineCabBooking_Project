using CabBookingEntity;
using CabBookingDal;
using System;

namespace CabBookingBL
{
    public class AreaBL
    {
        AreaRepository areaRepository = new AreaRepository();
        public void AddArea(Area area)
        {
            areaRepository.AddArea(area);
        }
        public Area GetAreaById(int id)
        {
            return areaRepository.GetAreaById(id);
        }

        public void UpdateChanges(Area area)
        {
            areaRepository.UpdateChanges(area);
        }

        public int DeleteLocation(int id)
        {
            return areaRepository.DeleteLocation(id);
        }
    }
}
