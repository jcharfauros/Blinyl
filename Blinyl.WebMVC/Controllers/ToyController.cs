using Blinyl.Data;
using Blinyl.Models;
using Blinyl.Services;
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
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Toy
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ToysService();
            var model = service.GetToys();

            return View(model);

            //var model = new ToyList[0];
            //return View(model);
        }

        // GET: Toy        
        public ActionResult Create()
        {
            return View();
        }
        // POST: Toy
        [HttpPost]        
        public ActionResult Create(Toy toy)
        {
            if (ModelState.IsValid)
            {
                _db.Toy.Add(toy);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toy);
        }
        // delete
        // GET: Toy/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toy toy = _db.Toy.Find(id);
            if (toy == null)
            {
                return HttpNotFound();
            }
            return View(toy);
        }
        // POST: Toy/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Toy toy = _db.Toy.Find(id);
            _db.Toy.Remove(toy);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // details
        // GET: Toy/Detail/{id}
        public ActionResult Details(int id)
        {
            var svc = CreatedToysService();
            var model = svc.GetToyById(id);

            return View(model);
        }
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Toy toy = _db.Toy.Find(id);
        //    if (toy == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(toy);
        //}

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
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Toy toy = _db.Toy.Find(id);
        //    if (toy == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(toy);
        //}
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

        private ToysService CreatedToysService()
        {
            var service = new ToysService();
            return service;
        }       
    }
}