using CabBookingBL;
using CabBookingEntity;
using OnlineCabBooking.Models;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class AreaController : Controller
    {
        LocationBL locationBL = new LocationBL();
        AreaBL areaBL = new AreaBL();
        public ActionResult ManageArea(int id)
        {
            ViewBag.GetArea = locationBL.GetArea(id);
            Session["LocationId"] = id;

            return View();
        }
        public ActionResult AddArea()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArea(AreaVM areaVM)
        {
           
            if (ModelState.IsValid)
            {
                Area area = new Area();
                area.LocationId = (int)Session["LocationId"];
                area.AreaName = areaVM.AreaName;
                areaBL.AddArea(area);
                return RedirectToAction("ManageArea",new { id = area.LocationId });
            }
            return View();
        }



        public ActionResult Edit(int id)
        {
            Area area = areaBL.GetAreaById(id);
          AreaVM areaVM = new AreaVM()
            {
                LocationId = area.LocationId,
                 AreaName= area.AreaName,
                 AreaId=area.AreaId
            };
            return View(areaVM);
        }
        [HttpPost]
        public ActionResult Edit(AreaVM areaVm)
        {
            if (ModelState.IsValid)
            {
                //var location = AutoMapper.Mapper.Map<Models.LocationVM, Location>(areaVm);
                Area area = new Area()
                {
                    LocationId = areaVm.LocationId,
                    AreaId = areaVm.AreaId,
                    AreaName = areaVm.AreaName
                };
                areaBL.UpdateChanges(area);
                return RedirectToAction("ManageArea",new { id = area.LocationId });
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
           int locationId= areaBL.DeleteLocation(id);
            return RedirectToAction("ManageArea", new { id = locationId });
        }






        // GET: Area
        public ActionResult GetArea(int id)
        {
           // Session["LocationId"] = id;
            ViewBag.Area = locationBL.GetArea(id);
            return View();
        }

        public ActionResult DropOff(int id)
        {
            Session["pickId"] = id;
            ViewBag.Drop = locationBL.DropOff(id);
            return View();
        }
    }
}