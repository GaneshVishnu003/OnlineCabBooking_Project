using CabBookingEntity;
using CabBookingDal;
using System;
using System.Collections.Generic;

namespace CabBookingBL
{
    public class AreaBL : IArea
    {
        IArea areaRepository = new AreaRepository();           //repository instance for admin interface object
        public void AddArea(Area area)              //adds new area
        {
            areaRepository.AddArea(area);
        }

        public IEnumerable<Area> GetArea(int id)        //shows the areas for pickup
        {
            return areaRepository.GetArea(id);
        }

        public IEnumerable<Area> DropOff(int id)            //gives remaining areas for drop off
        {
            //int pickupId = area.AreaId;
            return areaRepository.DropOff(id);
        }


        public Area GetAreaById(int id)             //gets the corresponding area for the id
        {
            return areaRepository.GetAreaById(id);
        }

        public void UpdateChanges(Area area)            //updates the edited area value
        {
            areaRepository.UpdateChanges(area);
        }

        public int GetLocationByArea(int id)            //gets the corresponding location for the id
        {
            return areaRepository.GetLocationByArea(id);
        }


        public void DeleteArea(int id)               //deletes the corresponding area in the location
        {
            areaRepository.DeleteArea(id);
        }
    }
}
