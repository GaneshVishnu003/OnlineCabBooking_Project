using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

public class CustomException : FilterAttribute, IExceptionFilter
{
    StringBuilder message = new StringBuilder();

    public void OnException(ExceptionContext filterContext)
    {
        message.Append(filterContext.RouteData.Values["controller"].ToString());
        message.Append(" ---> ");
        message.Append(filterContext.RouteData.Values["action"].ToString());
        message.Append(" ---> ");
        message.Append(filterContext.Exception.Message);
        message.Append(" ---> ");
        message.AppendLine(DateTime.Now.ToString());
        LogMessage(message.ToString());
        message.Clear();
        filterContext.ExceptionHandled = true;
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }
        else
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "ErrorSignUp"
            };
        }


    }
    protected void LogMessage(string message)
    {
        File.AppendAllText(HttpContext.Current.Server.MapPath("~/Logger/ExceptionLogger.txt"), message);
    }
}
