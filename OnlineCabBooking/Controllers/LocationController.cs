using CabBookingBL;
using CabBookingEntity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class LocationController : Controller
    {
        LocationBL locationBL = new LocationBL();

        public ActionResult Index()
        {
            IEnumerable<Location> location = locationBL.GetLocation();
            return View(location);
        }

        public ActionResult DisplayLocation()
        {
            ViewBag.Location = locationBL.GetLocation();
            return View();
        }
        [HttpGet]
        public ActionResult AddLocation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLocation(Models.LocationVM newLocation)
        {
            if (ModelState.IsValid)
            {
                Location location = new Location()
                {
                    CityName = newLocation.CityName,
                    DistrictName = newLocation.DistrictName
                };
                locationBL.AddLocation(location);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Location location = locationBL.GetlocationById(id);
            Models.LocationVM locationVM = new Models.LocationVM()
            {
                LocationId = location.LocationId,
                CityName = location.CityName,
                DistrictName = location.DistrictName
            };
            return View(locationVM);
        }
        [HttpPost]
        public ActionResult Edit(Models.LocationVM locationVm)
        {
            if (ModelState.IsValid)
            {
                var location = AutoMapper.Mapper.Map<Models.LocationVM, Location>(locationVm);
                locationBL.UpdateChanges(location);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            locationBL.DeleteLocation(id);
            return RedirectToAction("Index");
        }



        // Area actions
        //public ActionResult GetArea(int id)
        //{
        //    ViewBag.Area = locationBL.GetArea(id);
        //    return View();
        //}

        //public ActionResult DropOff(int id)
        //{
        //    ViewBag.Drop= locationBL.DropOff(id);
        //    return View();
        //}
    }
}