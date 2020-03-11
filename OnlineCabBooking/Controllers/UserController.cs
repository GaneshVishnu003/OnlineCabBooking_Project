using CabBookingDal;
using CabBookingEntity;
using System.Web.Mvc;
using OnlineCabBooking.Models;
using System.Collections.Generic;

namespace OnlineCabBooking.Controllers
{
   // [HandleError]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: User
        public ActionResult SignUp()
        {
            ViewBag.Roles = new SelectList(UserRepository.GetRoles(), "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpVM signUp)
        {
           ViewBag.Roles = new SelectList(UserRepository.GetRoles(), "RoleId", "RoleName");
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<SignUpVM, User>(signUp);
                UserRepository userRepository = new UserRepository();
                userRepository.SignUp(user);
               // return View();
            }
           
            if (signUp.RoleId == 2)
            {
                int id = UserRepository.GetUserId(signUp.MailId);
                TempData["id"] = id;
                return RedirectToAction("SignUpNext");
            }
            else
            {
                ViewBag.success = "Logged in successfully as Customer";
                return View();
            }
        }
        public ActionResult SignUpNext()
        {
            ViewBag.Type = new SelectList(UserRepository.GetCabType(), "TypeId", "TypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpNext(SignUpNextVM signUp)
        {
            ViewBag.Type = new SelectList(UserRepository.GetCabType(), "TypeId", "TypeName");
            signUp.UserId = (int)TempData["id"];
            var cab = AutoMapper.Mapper.Map<SignUpNextVM,Cab>(signUp);
            UserRepository userRepository = new UserRepository();
            userRepository.SignUpNext(cab);
            ViewBag.success = "Logged in successfully as Driver";
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInVM signIn)
        {
            var user = AutoMapper.Mapper.Map<SignInVM, User>(signIn);
          
            User value = UserRepository.CheckLogin(user);
            if (value != null)
            {
                if (value.RoleId == 1)
                {
                    ViewBag.value = "Logged in Successfully as Customer";
                    return View();     //need to change
                }
                else if (value.RoleId == 2)
                {
                    ViewBag.value = "Logged in successfully as Driver";
                    return View();   //need to change
                }
                else if (value.RoleId == 3)
                {
                    ViewBag.value = "Logged in successfully as Admin";
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    ViewBag.value = "Please enter correct details";
                    return View();
                }
            }
            else
            {
                ViewBag.value = "Please enter correct details";
                return View();
            }
        }
    }
}