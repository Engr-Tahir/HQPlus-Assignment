﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task3.WebServiceAPI.Controllers {
    public class HomeController : Controller {
        public ActionResult Index()   {
            ViewBag.Title = "HQPlus Assignment - TAHIR MAJEED ";
            return View();
        }
    }
}
