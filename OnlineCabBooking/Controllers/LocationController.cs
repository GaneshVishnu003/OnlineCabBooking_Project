using CabBookingBL;
using CabBookingEntity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class LocationController : Controller
    {
        ILocationBL locationBL;
        public LocationController()
        {
            locationBL = new LocationBL();
        }

        public ActionResult Map()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        //shows the home page for location handling
        public ActionResult Index()
        {

            IEnumerable<Location> location = locationBL.GetLocation();
            return View(location);
        }

        //displays the location
        public ActionResult DisplayLocation()
        {

            ViewBag.Location = locationBL.GetLocation();
            return View();
        }

        //adds new location
        public ActionResult AddLocation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //post method for adding location
        public ActionResult AddLocation(Models.LocationVM newLocation)
        {
            if (ModelState.IsValid)
            {
                var location = AutoMapper.Mapper.Map<Models.LocationVM, Location>(newLocation);
                locationBL.AddLocation(location);
                return RedirectToAction("Index");
            }
            return View();
        }

        //edits the current location
        public ActionResult Edit(int id)
        {
            Location location = locationBL.GetlocationById(id);
            var locationVM = AutoMapper.Mapper.Map<Location, Models.LocationVM>(location);
            return View(locationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //post method for editing the location
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

        //deletes the corresponding location
        public ActionResult Delete(int id)
        {
            locationBL.DeleteLocation(id);
            return RedirectToAction("Index");
        }
    }
}