using CabBookingDal;
using CabBookingEntity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class AdminController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: Admin
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(OnlineCabBooking.Models.AdminSignIn signIn)
        {
            bool value = AdminRepository.CheckLogin(signIn.UserName, signIn.Password);
            if (value)
            {
                ViewBag.value = "Logged in Successfully";

                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.value = "Please enter correct details";
                return View();
            }
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            userRepository.DeleteUser(id);
            return RedirectToAction("DisplayUser");
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
        public ActionResult DisplayUser()
        {
            IEnumerable<CabBookingEntity.User> user = UserRepository.GetUserDetails();
            return View(user);
        }
    }
}