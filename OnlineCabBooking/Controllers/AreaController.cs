using CabBookingBL;
using CabBookingDal;
using CabBookingEntity;
using OnlineCabBooking.Models;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class AreaController : Controller
    {
        //LocationBL locationBL = new LocationBL();
        IArea areaBL= new AreaBL();
        public ActionResult ManageArea(int id)              //Shows page for managing the areas
        {
            ViewBag.GetArea = areaBL.GetArea(id);
            Session["LocationId"] = id;

            return View();
        }
        public ActionResult AddArea()           //adds new area
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArea(AreaVM areaVM)      //post method for adding area
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



        public ActionResult Edit(int id)        //calls ediit for the area
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
        public ActionResult Edit(AreaVM areaVm)         //post method for editing the area
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
        public ActionResult Delete(int id)          //deletes the area in the corresponding id
        {
           
                areaBL.DeleteArea(id);
            //int locationId = areaBL.GetLocationByArea(id);        //need correction for exception
            //return RedirectToAction("ManageArea", new { id = locationId });

            return RedirectToAction("index", "location");
        }




        // GET: Area
        public ActionResult GetArea(int id)
        {
           // Session["LocationId"] = id;
            ViewBag.Area = areaBL.GetArea(id);
            return View();
        }

        public ActionResult DropOff(int id)
        {
            Session["pickId"] = id;
            ViewBag.Drop = areaBL.DropOff(id);
            return View();
        }
    }
}