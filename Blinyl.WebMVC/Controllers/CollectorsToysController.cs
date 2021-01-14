using Blinyl.Data;
using Blinyl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blinyl.WebMVC.Controllers
{
    public class CollectorsToysController : Controller
    {
        //JULIA NOTE: does a list need DB?
        //private ApplicationDbContext _dbCollector = new ApplicationDbContext();

        // GET: CollectorsToys
        public ActionResult Index()
        {
            var model = new CollectorsToysList[0];
            return View(model);
        }

        // GET: CollectorsToys
        public ActionResult Create()
        {
            return View();
        }
        // POST: CollectorsToys        
        // |DELETE|
        // GET: CollectorsToys/Delete/{id}        
        // POST: CollectorsToys/Delete/{id}   
        // |UPDATE|
        // GET: CollectorsToys/Edit/{id}
        // POST: CollectorsToys/Edit/{id}
        // |DETAILS|
        // GET: CollectorsToys/Details/{id}
    }
}