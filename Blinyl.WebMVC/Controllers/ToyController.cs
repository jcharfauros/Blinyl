using Blinyl.Data;
using Blinyl.Models;
using Blinyl.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ToysService(userId);
            //var service = new ToysService();
            var model = service.GetToys();

            return View(model);
        }

        // GET: Toy        
        public ActionResult Create()
        {
            return View();
        }
        // POST: Toy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToyCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreatedToysService();

            if (service.CreateToy(model))
            {
                TempData["SaveResult"] = "Your BLINYL was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "BLINYL could not be added.");

            return View(model);                                        
        }
        
        // details
        // GET: Toy/Detail/{id}
        public ActionResult Details(int id)
        {
            var svc = CreatedToysService();
            var model = svc.GetToyById(id);

            return View(model);
        }
        
        // update
        // GET: Toy/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreatedToysService();
            var detail = service.GetToyById(id);
            var model =
                new ToyEdit
                {
                    ToyId = detail.ToyId,
                    Name = detail.Name,
                    Brand = detail.Brand,
                    Series = detail.Series,
                    Artist = detail.Artist,
                    Description = detail.Description,
                    ReleaseYear = detail.ReleaseYear,
                    RetailPrice = detail.RetailPrice
                };
            return View(model);
        }
        
        // POST: Toy/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToyEdit model)
        {
            if (ModelState.IsValid) return View(model);

            if(model.ToyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatedToysService();

            if (service.UpdateToy(model))
            {
                TempData["SaveResult"] = "Your note was upated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This blindbox/toy could not be updated.");
            return View();
        }
        // delete
        // GET: Toy/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatedToysService();
            var model = svc.GetToyById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteToy(int id)
        {
            var service = CreatedToysService();

            service.DeleteToy(id);

            TempData["SaveResult"] = "The selected Blinyl was deleted.";

            return RedirectToAction("Index");
        }

        private ToysService CreatedToysService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ToysService(userId);
            //var service = new ToysService();
            return service;
        }       
    }
}