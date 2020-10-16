using CabBookingBL;
using System.Web.Mvc;
using OnlineCabBooking.Models;
using CabBookingEntity;
using System.Web.Security;
using System.Web;
using System;

namespace OnlineCabBooking.Controllers
{
    
    public class UserController : Controller
    {
        IUserBL userBL;
        public UserController()
        {
            userBL = new UserBL();
        }

        //gets the home page
        public ActionResult Index()             
        {
            return View();
        }

        //renders the sign up  form
        public ActionResult SignUp()            
        {
            if (TempData["Roles"] == null)          //checks for roles available through admin
                TempData["Roles"] = new SelectList(userBL.GetRoles(), "RoleId", "RoleName");    //gets roles except admin
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //post action for sign up
        public ActionResult SignUp(SignUpVM signUp)             
        {
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<SignUpVM, User>(signUp);
                userBL.SignUp(user);
                if (user.Role.RoleName == UserRoles.Driver.ToString())
                {
                    int userId = userBL.GetUserId(signUp.MailId);
                    TempData["id"] = userId;
                    return RedirectToAction("DriverRegistration");
                }
                return View("SignIn");
            }
            if (TempData["Roles"] == null)      //checks for roles available through admin
                TempData["Roles"] = new SelectList(userBL.GetRoles(), "RoleId", "RoleName");
            return View();
        }

        //logs out the user
        public ActionResult LogOut()    
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("index", "user");
        }

        //sign up form for cab registration
        public ActionResult DriverRegistration()        
        {
            ViewBag.Type = new SelectList(userBL.GetCabType(), "TypeId", "TypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //post method for cab registration
        public ActionResult DriverRegistration(DriverRegistration signUp)         
        {
            ViewBag.Type = new SelectList(userBL.GetCabType(), "TypeId", "TypeName");
            if(TempData["id"]==null)
            {
                return View("SignUp");
            }
            signUp.UserId = (int)TempData["id"];
            var cab = AutoMapper.Mapper.Map<DriverRegistration, Cab>(signUp);
            userBL.DriverRegistration(cab);
            ViewBag.success = "Logged in successfully as Driver";
            return View("SignIn");
        }

        //renders the sign in form
        public ActionResult SignIn()            
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //post action for sign in
        public ActionResult SignIn(SignInVM signIn)         
        {
            var user = AutoMapper.Mapper.Map<SignInVM, User>(signIn);
            User value = userBL.CheckLogin(user);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.MailId, false);
                var authTicket = new FormsAuthenticationTicket(1, value.MailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, value.Role.RoleName);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                Session["FirstName"] = value.FirstName;
                Session["userId"] = value.UserId;
                ViewBag.value = "Logged in successfully as " + value.Role.RoleName;    
                if (value.Role.RoleName == UserRoles.Customer.ToString())                //check for customer
                    return RedirectToAction("index", "user");
                else if (value.Role.RoleName == UserRoles.Driver.ToString())         //check for driver
                    return RedirectToAction("index", "user"); 
                else if (value.Role.RoleName == UserRoles.Admin.ToString())         //check for admin 
                    return RedirectToAction("Home", "Admin");
            }
            ViewBag.value = "Please enter correct details";
            return View();
        }
    }
}