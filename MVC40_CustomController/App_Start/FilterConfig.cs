﻿using System.Web;
using System.Web.Mvc;

namespace MVC40_CustomController
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}