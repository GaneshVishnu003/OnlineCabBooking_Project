using CabBookingEntity;
using CabBookingDal;
using System;
using System.Collections.Generic;

namespace CabBookingBL
{
    public class AreaBL : IAreaBL
    {
        IArea areaRepository;           
        public AreaBL()
        {
            areaRepository = new AreaRepository();
        }

        //adds new area
        public void AddArea(Area area)              
        {
            areaRepository.AddArea(area);
        }

        //shows the areas for pickup
        public IEnumerable<Area> GetArea(int id)       
        {
            return areaRepository.GetArea(id);
        }

        //gives remaining areas for drop off
        public IEnumerable<Area> DropOff(int id)            
        {
            return areaRepository.DropOff(id);
        }

        //gets the corresponding area for the id
        public Area GetAreaById(int id)             
        {
            return areaRepository.GetAreaById(id);
        }

        //updates the edited area value
        public void UpdateChanges(Area area)            
        {
            areaRepository.UpdateChanges(area);
        }

        //gets the corresponding location for the id
        public int GetLocationByArea(int id)            
        {
            return areaRepository.GetLocationByArea(id);
        }

        //deletes the corresponding area in the location
        public void DeleteArea(int id)               
        {
            areaRepository.DeleteArea(id);
        }
    }
}
