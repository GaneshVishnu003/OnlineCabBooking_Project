﻿using System.Web.Mvc;

namespace OnlineCabBooking
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomException());
           // filters.Add(new HandleErrorAttribute());
        }
    }
}
