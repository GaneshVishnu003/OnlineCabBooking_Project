using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AdminError()       //shows the page when error is occured in Admin with message
        {
            return View();
        }

        public ActionResult UserError()         //shows the page as error without internal message
        {
            return View();
        }
    }
}