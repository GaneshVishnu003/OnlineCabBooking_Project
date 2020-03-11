using CabBookingDal;
using CabBookingEntity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    
    public class AdminController : Controller
    {
        UserRepository userRepository = new UserRepository();
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult DeleteCustomer(int id)
        {
            userRepository.DeleteUser(id);
            return RedirectToAction("DisplayCustomer");
        }
        public ActionResult DeleteDriver(int id)
        {
            userRepository.DeleteUser(id);
            return RedirectToAction("DisplayDriver");
        }
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{ 
        //    User user = userRepository.GetUserById(id);
        //    return View(user);
        //}
        //[HttpPost]
        //public ActionResult Edit(CabBookingEntity.User user)
        //{
        //    userRepository.UpdateChanges(user);
        //    return View();
        //}
        //[Authorize]
        public ActionResult DisplayCustomer()
        {
            IEnumerable<CabBookingEntity.User> user = UserRepository.GetCustomerDetails();
            return View(user);
        }
        public ActionResult DisplayDriver()
        {
            IEnumerable<CabBookingEntity.User> user = UserRepository.GetDriverDetails();
            return View(user);
        }
    }
}