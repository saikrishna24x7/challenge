﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingChallenge.Controllers
{
    public class WeatherController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
    }
}
