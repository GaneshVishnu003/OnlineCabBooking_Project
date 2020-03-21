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
        public ActionResult Home()          //admin main page 
        {
            return View();
        }
        public ActionResult DeleteCustomer(int id)      //call for deleting the customer
        {
            adminBL.DeleteUser(id);
            return RedirectToAction("DisplayCustomer");
        }
        public ActionResult DeleteDriver(int id)         //call for deleting the driver
        {
            adminBL.DeleteUser(id);
            return RedirectToAction("DisplayDriver");
        }
        [Authorize]
        public ActionResult DisplayCustomer()               //call for displaying the customer
        {
            IEnumerable<User> user = adminBL.GetCustomerDetails();
            return View(user);
        }
        public ActionResult DisplayDriver()             //call for displaying the driver
        {
            IEnumerable<User> user = adminBL.GetDriverDetails();
            return View(user);
        }
        
        public ActionResult AddAdmin()          //adds new admin
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(SignUpVM signUp)           //post method for adding the admin
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