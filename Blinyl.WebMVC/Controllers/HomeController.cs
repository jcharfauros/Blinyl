using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blinyl.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What is BLINYL?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Blinyl";

            return View();
        }
    }
}