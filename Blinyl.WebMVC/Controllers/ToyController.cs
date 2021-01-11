using Blinyl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blinyl.WebMVC.Controllers
{
    [Authorize]
    public class ToyController : Controller
    {
        // GET: Toy
        public ActionResult Index()
        {
            var model = new ToyList[0];
            return View(model);
        }

        // GET: Create Toy        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToyCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);

        }
    }
}