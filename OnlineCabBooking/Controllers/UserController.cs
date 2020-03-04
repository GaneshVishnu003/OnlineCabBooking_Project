using CabBookingDal;
using CabBookingEntity;
using System.Web.Mvc;
using OnlineCabBooking.Models;
namespace OnlineCabBooking.Controllers
{
   // [HandleError]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult SignUp()
        {
            ViewBag.Roles = new SelectList(UserRepository.GetRoles(), "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpVM signUp)
        {
           ViewBag.Roles = new SelectList(UserRepository.GetRoles(), "RoleId", "RoleName");
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<SignUpVM, User>(signUp);
                //User user = new User();
                //user.FirstName = signUp.FirstName;
                //user.LastName = signUp.LastName;
                //user.RoleId = signUp.RoleId;
                //user.MailId = signUp.MailId;
                //user.MobileNumber = signUp.MobileNumber;
                //user.Password = signUp.Password;
                UserRepository userRepository = new UserRepository();
                userRepository.SignUp(user);
               // return View();
            }
            ViewBag.success = "Logged in successfully";
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(OnlineCabBooking.Models.SignInVM signIn)
        {
            int value=UserRepository.CheckLogin(signIn.MailId,signIn.Password);
            if (value==1)
            {
                ViewBag.value = "Logged in Successfully as Customer";
            }
            else if(value==2)
            {
                ViewBag.value = "Logged in successfully as Driver";
            }
            else if(value==3)
            {
                ViewBag.value = "Logged in successfully as Admin";
                return RedirectToAction("Index", "Admin");
            }
       else
                ViewBag.value = "Please enter correct details";
                return View();
        }
    }
}