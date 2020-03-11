using CabBookingDal;
using CabBookingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class LocationController : Controller
    {
        LocationRepository locationRepository = new LocationRepository();
        // GET: Location
        public ActionResult Index()
        {

            // LocationRepository locationRepository = new LocationRepository();
            IEnumerable<Location> location = locationRepository.GetLocation();
            return View(location);
        }
        [HttpGet]
        public ActionResult AddLocation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLocation(OnlineCabBooking.Models.LocationVM newLocation)
        {
            if (ModelState.IsValid)
            {
                Location location = new Location()
                {
                    CityName = newLocation.CityName,
                    DistrictName = newLocation.DistrictName
                };
                UserContext userContext = new UserContext();
                locationRepository.AddLocation(location);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            // LocationRepository location
            Location location = locationRepository.GetlocationById(id);
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
            // LocationRepository location
            if (ModelState.IsValid)
            {
                var location = AutoMapper.Mapper.Map<Models.LocationVM, Location>(locationVm);
                //Location location = new Location()
                //{
                //    LocationId=locationVm.LocationId,
                //    CityName = locationVm.CityName,
                //    DistrictName = locationVm.DistrictName
                //};
                locationRepository.UpdateChanges(location);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            locationRepository.DeleteLocation(id);
            return RedirectToAction("Index");
        }
    }
}