using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCabBooking.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorAction()       //shows the page when error is occured
        {
            return View();
        }
    }
}