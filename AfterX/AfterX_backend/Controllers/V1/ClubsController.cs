using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Controllers.V1
{
    public class ClubsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
