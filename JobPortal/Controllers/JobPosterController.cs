using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    public class JobPosterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
