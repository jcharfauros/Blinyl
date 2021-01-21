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
        
        // update
        // GET: Toy/Edit/{id}
        public ActionResult Edit(int? id)
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
        // POST: Toy/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Toy toy)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(toy).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toy);
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
        private ToysService CreatedToysService()
        {
            var service = new ToysService();
            return service;
        }       
    }
}