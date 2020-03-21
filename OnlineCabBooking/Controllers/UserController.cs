using CabBookingBL;
using System.Web.Mvc;
using OnlineCabBooking.Models;
using System.Collections.Generic;
using CabBookingEntity;


namespace OnlineCabBooking.Controllers
{
   // [HandleError]
    public class UserController : Controller
    {
        UserBL userBL = new CabBookingBL.UserBL();

        [HttpGet]
        public ActionResult Index()             //gets the home page
        {
            if (Session["FirstName"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Logout","user");
            }
        }
        // GET: User
        [HttpGet]
        public ActionResult SignUp()            //renders the sign up  form
        {
            ViewBag.Roles = new SelectList(userBL.GetRoles(), "RoleId", "RoleName");
            return View();
        }
        // [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SignUp(SignUpVM signUp)             //post action for sign up
        {
           ViewBag.Roles = new SelectList(userBL.GetRoles(), "RoleId", "RoleName");
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<SignUpVM, User>(signUp);
                userBL.SignUp(user);
                if (signUp.RoleId == 2)
                {
                    
                     int userId = userBL.GetUserId(signUp.MailId);
                    TempData["id"] = userId;
                    //Session["FirstName"] = userData.FirstName;
                    return RedirectToAction("SignUpNext");
                }
                else
                {
                    //ViewBag.success = "Registered successfully as Customer";
                    return View("SignIn");
                }
            }
            return View();
        }

        public ActionResult LogOut()    //logs out the user
        {
            Session.Abandon();
            return RedirectToAction("index","user");
        }

        public ActionResult SignUpNext()        //sign up form for cab registration
        {
            ViewBag.Type = new SelectList(userBL.GetCabType(), "TypeId", "TypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpNext(SignUpNextVM signUp)         //post method for cab registration
        {
            ViewBag.Type = new SelectList(userBL.GetCabType(), "TypeId", "TypeName");
            signUp.UserId = (int)TempData["id"];
            var cab = AutoMapper.Mapper.Map<SignUpNextVM,Cab>(signUp);
           // UserRepository userRepository = new UserRepository();
            userBL.SignUpNext(cab);
            ViewBag.success = "Logged in successfully as Driver";
            return View();
        }
        public ActionResult SignIn()            //renders the sign in form
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInVM signIn)         //post action for sign in
        {
            var user = AutoMapper.Mapper.Map<SignInVM, User>(signIn);
          
            User value = userBL.CheckLogin(user);
            if (value != null)
            {
                Session["FirstName"] = value.FirstName;
                Session["userId"] = value.UserId;
                if (value.RoleId == 1)                  //check for customer
                {
                    ViewBag.value = "Logged in Successfully as Customer";
                    return RedirectToAction("DisplayLocation", "Location"); ;     //need to change
                }
                else if (value.RoleId == 2)         //check for driver
                {
                    ViewBag.value = "Logged in successfully as Driver";
                    return View();   //need to change
                }
                else if (value.RoleId == 3)         //check for admin                        
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