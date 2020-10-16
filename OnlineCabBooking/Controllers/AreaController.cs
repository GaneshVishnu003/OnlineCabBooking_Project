using CabBookingBL;
using CabBookingEntity;
using OnlineCabBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class AreaController : Controller
    {
        IAreaBL areaBL;
        public AreaController()
        {
            areaBL = new AreaBL();
        }

        [Authorize(Roles = "Admin")]
        //Shows page for managing the areas
        public ActionResult ManageArea(int id)              
        {
           IEnumerable<Area> areaVM = areaBL.GetArea(id);       //gets all the area in the location
           TempData["LocationId"] = id;
           return View(areaVM);
        }

        [Authorize(Roles = "Admin")]
        //adds new area
        public ActionResult AddArea()           
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //post method for adding area
        public ActionResult AddArea(AreaVM areaVM)      
        {
            if (ModelState.IsValid)
            {
                Area area = new Area();
                area.LocationId = (int)TempData.Peek("LocationId");     //assign the location id    
                area.AreaName = areaVM.AreaName;                        //assign the area name
                areaBL.AddArea(area);
                return RedirectToAction("ManageArea", new { id = area.LocationId });
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        //calls edit for the area
        public ActionResult Edit(int id)        
        {

            Area area = areaBL.GetAreaById(id);
            var areaVM = AutoMapper.Mapper.Map<Area, AreaVM>(area);
            return View(areaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //post method for editing the area
        public ActionResult Edit(AreaVM areaVm)         
        {
            if (ModelState.IsValid)
            {
                var area = AutoMapper.Mapper.Map<AreaVM, Area>(areaVm);
                areaBL.UpdateChanges(area);
                return RedirectToAction("ManageArea", new { id = area.LocationId });
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        //deletes the area in the corresponding id
        public ActionResult Delete(int id)          
        {
            areaBL.DeleteArea(id);
            return RedirectToAction("index", "location");
        }

        // gets all the area for choosing the pickup area
        public ActionResult GetArea(int id)     
        {
            ViewBag.Area = areaBL.GetArea(id);
            return View();
        }

        // gets all the area except pickup area for choosing the dropoff area
        public ActionResult DropOff(int id)
        {
            ViewBag.Drop = areaBL.DropOff(id);
            return View();
        }
    }
}