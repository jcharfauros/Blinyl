using Blinyl.Data;
using Blinyl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blinyl.Services
{
    public class WishlistService
    {
        private readonly Guid _userId;
        public WishlistService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateWishlist(WishListCreate model)
        {
            var entity =
                new Wishlist()
                {
                    OwnerId = _userId,
                    WishListTitle = model.WishListTitle,
                    Toys = model.Toys
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Wishlist.Add(entity);                
                return ctx.SaveChanges() == 1;
            }
        }
        //Helper method for toyslist
        public IEnumerable<SelectListItem> GetToysForMultiSelect()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Toys.Select(toy => new SelectListItem                                       
                    {
                        Text = toy.Name,
                        Value = toy.ToyId.ToString(),                        
                    });
                
                return query.ToArray();
            }
        }

        public IEnumerable<WishListItem> Getwishlist()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var wishlists =
                    ctx
                        .Wishlist
                        .Select(w => new WishListItem()
                        {
                            WishId = w.WishId,
                            WishListTitle = w.WishListTitle

                        });

                return wishlists.ToList();
            }
        }

        public WishListDetail GetWishlistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                        .Wishlist
                        .Single(w => w.WishId == id && w.OwnerId == _userId);
                return
                    new WishListDetail
                    {
                        WishId = entity.WishId,
                        WishListTitle = entity.WishListTitle
                    };
            }
        }

        public bool UpdateWishlist(WishListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Wishlist
                        .Single(w => w.WishId == model.WishId && w.OwnerId == _userId);

                entity.WishListTitle = model.WishListTitle;

                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteWishlist(int wishId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Wishlist
                        .Single(w => w.WishId == wishId && w.OwnerId == _userId);

                ctx.Wishlist.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
