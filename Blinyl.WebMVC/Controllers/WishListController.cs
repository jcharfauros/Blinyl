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
            return View();
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
                TempData["SaveResult"] = "xxxx";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "xxxx");

            return View(model);
        }

        // GET: Wishlist/{id}
        //public ActionResult Details(int id)
        //{

        //}

        // READ
        // UPDATE/EDIT
        // DELETE

        private WishlistService CreateWishlistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WishlistService(userId);

            return service;
        }

    }
}