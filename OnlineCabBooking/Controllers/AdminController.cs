using CabBookingBL;
using CabBookingEntity;
using OnlineCabBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    
    public class AdminController : Controller
    {
        AdminBL adminBL = new AdminBL();
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult DeleteCustomer(int id)
        {
            adminBL.DeleteUser(id);
            return RedirectToAction("DisplayCustomer");
        }
        public ActionResult DeleteDriver(int id)
        {
            adminBL.DeleteUser(id);
            return RedirectToAction("DisplayDriver");
        }
        //[Authorize]
        public ActionResult DisplayCustomer()
        {
            IEnumerable<User> user = AdminBL.GetCustomerDetails();
            return View(user);
        }
        public ActionResult DisplayDriver()
        {
            IEnumerable<User> user = AdminBL.GetDriverDetails();
            return View(user);
        }
        
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(SignUpVM signUp)
        {
            if(ModelState.IsValid)
            {
                signUp.RoleId = 3;
                var user=AutoMapper.Mapper.Map<SignUpVM, User>(signUp);
                UserBL userBL = new UserBL();
                userBL.SignUp(user);
            }
            return View();
        }
        //public ActionResult HandleLocations()
        //{  
        //    LocationBL locationBL = new LocationBL();
        //    IEnumerable<Location> location = locationBL.GetLocation();  // got from index in location controller
        //    return View(location);
        //}
    }
}