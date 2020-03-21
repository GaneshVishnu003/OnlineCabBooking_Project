using CabBookingBL;
using CabBookingEntity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class LocationController : Controller
    {
        LocationBL locationBL = new LocationBL();

        public ActionResult Index()         //shows the home page for location handling
        {
            IEnumerable<Location> location = locationBL.GetLocation();
            return View(location);
        }

        public ActionResult DisplayLocation()           //displays the location
        {
            ViewBag.Location = locationBL.GetLocation();
            return View();
        }
        [HttpGet]
        public ActionResult AddLocation()           //adds new location
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLocation(Models.LocationVM newLocation)          //post method for adding location
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

        public ActionResult Edit(int id)        //edits the current location
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
        public ActionResult Edit(Models.LocationVM locationVm)      //post method for editing the location
        {
            if (ModelState.IsValid)
            {
                var location = AutoMapper.Mapper.Map<Models.LocationVM, Location>(locationVm);
                locationBL.UpdateChanges(location);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)              //deletes the corresponding location
        {
            locationBL.DeleteLocation(id);
            return RedirectToAction("Index");
        }
    }
}