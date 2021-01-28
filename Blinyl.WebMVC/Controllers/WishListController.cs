using Blinyl.Data;
using Blinyl.Models;
using Blinyl.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blinyl.WebMVC.Controllers
{
    public class WishListController : Controller
    {
        //GET: WishList
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WishlistService(userId);
            var model = service.Getwishlist();

            return View(model);
        }

        // CREATE
        public ActionResult Create()
        {
            var service = CreateWishlistService();
            var toysList = service.GetToysForMultiSelect();

            ViewBag.Toys = new MultiSelectList(toysList, "Value", "Text");

            return View();
        }
        // POST : Wishlist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WishListCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWishlistService();
            var toysList= service.GetToysForMultiSelect();

            ViewBag.Toys = new MultiSelectList(toysList, "Value", "Text");

            if (service.CreateWishlist(model))
            {
                TempData["SaveResult"] = "Neat! Your wishlist was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "DOH! Your wishlist didn't save!");

            return View(model);
        }

        // details
        // GET: Wishlist/{id}
        public ActionResult Details(int id)
        {
            var service = CreateWishlistService();
            var model = service.GetWishlistById(id);

            return View(model);
        }

        // update
        // GET: Wishlist/Edit/{id}        
        public ActionResult Edit(int id)
        {
            var service = CreateWishlistService();
            var detail = service.GetWishlistById(id);
            var model =
                new WishListEdit
                {
                    WishListTitle = detail.WishListTitle,
                };
            return View(model);
        }
        //overloaded edit
        //POST: Wishlist/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WishListEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.WishId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateWishlistService();

            if (service.UpdateWishlist(model))
            {
                TempData["SaveResult"] = "Your wish list was upated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This wish list could not be updated.");
            return View();
        }

        // DELETE
        // GET: Wishlist/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateWishlistService();
            var model = service.GetWishlistById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWishlist(int id)
        {
            var service = CreateWishlistService();

            service.DeleteWishlist(id);

            TempData["SaveResult"] = "The wish list was deleted.";

            return RedirectToAction("Index");
        }

        //Helper
        private WishlistService CreateWishlistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WishlistService(userId);

            return service;
        }

    }
}