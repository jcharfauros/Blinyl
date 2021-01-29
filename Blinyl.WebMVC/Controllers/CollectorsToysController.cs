using Blinyl.Data;
using Blinyl.Models;
using Blinyl.Services;
using Microsoft.AspNet.Identity;
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
        //GET: CollectorsToys
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectorService(userId);
            var model = service.GetCList();

            return View(model);
        }

        // GET: CollectorsToys
        public ActionResult Create()
        {
            var service = CreateCollectorService();
            var collectList = service.GetCListMultiSelect();

            ViewBag.Toys = new MultiSelectList(collectList, "Value", "Text");
            return View();
        }
        // POST: CollectorsToys
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CollectorsToysCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCollectorService();
            var toysList = service.GetCListMultiSelect();

            ViewBag.Toys = new MultiSelectList(toysList, "Value", "Text");

            if (service.CreateClist(model))
            {
                TempData["SaveResult"] = "Neat! Your list was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "DOH! Your list didn't save!");

            return View(model);
        }

        // details
        // GET: CollectorsToys/{id}
        public ActionResult Details(int id)
        {
            var service = CreateCollectorService();
            var model = service.GetCListById(id);

            return View(model);
        }

        // update
        // GET: CollectorsToys/Edit/{id}        
        public ActionResult Edit(int id)
        {
            var service = CreateCollectorService();
            var detail = service.GetCListById(id);
            var model =
                new CollectorsToys
                {
                    Title = detail.Title,
                };
            return View(model);
        }
        //overloaded edit
        //POST: Wishlist/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CollectorsToysEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CollectorsToysId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateCollectorService();

            if (service.UpdateCollectorlist(model))
            {
                TempData["SaveResult"] = "Your collector list was upated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This collector list could not be updated.");
            return View();
        }

        // DELETE
        // GET: CollectorsToys/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateCollectorService();
            var model = service.GetCListById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWishlist(int id)
        {
            var service = CreateCollectorService();

            service.DeleteCollectorlist(id);

            TempData["SaveResult"] = "The BLINYL collection was deleted.";

            return RedirectToAction("Index");
        }

        //Helper
        private CollectorService CreateCollectorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectorService(userId);

            return service;
        }
    }
}