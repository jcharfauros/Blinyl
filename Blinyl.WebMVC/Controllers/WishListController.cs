using Blinyl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blinyl.WebMVC.Controllers
{
    public class WishListController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: WishList
        public ActionResult Index()
        {
            List<Wishlist> toyList = _db.Wishlist.ToList();
            List<Wishlist> wishlist = toyList.OrderBy(item => item.WishListTitle).ToList();
            return View(wishlist);
    }

        // GET: Wishlist
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wishlist
        [HttpPost]
        public ActionResult Create(Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                _db.Wishlist.Add(wishlist);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wishlist);
        }
    }
}