﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX.Controllers.V1
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Home()
        {
            return Redirect("/swagger");
        }
    }
}
