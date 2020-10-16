using CabBookingBL;
using CabBookingEntity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IAdminBL adminBL;
        public AdminController()
        {
            adminBL = new AdminBL();
        }

        //admin main page 
        public ActionResult Home()
        {
            return View();
        }

        //call for displaying the customer
        public ActionResult DisplayCustomer()
        {
            IEnumerable<User> user = adminBL.GetCustomerDetails();
            return View(user);
        }

        //call for displaying the driver
        public ActionResult DisplayDriver()
        {
            IEnumerable<User> user = adminBL.GetDriverDetails();
            return View(user);
        }

        //calls for deleting the customer
        public ActionResult DeleteCustomer(int id)
        {
            adminBL.DeleteUser(id);
            return RedirectToAction("DisplayCustomer");
        }

        //call for deleting the driver
        public ActionResult DeleteDriver(int id)
        {
            adminBL.DeleteUser(id);
            return RedirectToAction("DisplayDriver");
        }

        //adds new admin
        public ActionResult AddAdmin()
        {
            TempData["Roles"] = new SelectList(adminBL.GetAllRoles(), "RoleId", "RoleName");  //gets all the roles for selection
            return RedirectToAction("SignUp", "User");
        }
    }
}