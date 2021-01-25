using Blinyl.Data;
using Blinyl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Services
{
    public class ToysService
    {
        public bool CreateToy(ToyCreate model)
        {
            var entity =
                new Toy()
                {
                    Name = model.Name,
                    Brand = model.Brand,
                    Series = model.Series,
                    Artist = model.Artist,
                    Description = model.Description,
                    ReleaseYear = model.ReleaseYear,
                    RetailPrice = model.RetailPrice,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Toy.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ToyList> GetToys()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Toy
                        .Select(
                            e => 
                                new ToyList
                                {
                                    ToyId = e.ToyId,
                                    Name = e.Name,
                                    Brand = e.Brand,
                                }
                         );
                return query.ToArray();
            }
        }

        public ToyDetail GetToyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Toy
                        .Single(e => e.ToyId == id);
                return
                    new ToyDetail
                    {
                        ToyId = entity.ToyId,
                        Name = entity.Name,
                        Brand = entity.Brand,
                        Series = entity.Series,
                        Description = entity.Description,
                        ReleaseYear = entity.ReleaseYear,
                        RetailPrice = entity.RetailPrice
                    };
            }
        }
        public bool UpdateToy(ToyEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Toy
                        .Single(e => e.ToyId == model.ToyId);

                entity.Name = model.Name;
                entity.Brand = model.Brand;
                entity.Series = model.Series;
                entity.Artist = model.Artist;
                entity.Description = model.Description;
                entity.ReleaseYear = model.ReleaseYear;
                entity.RetailPrice = model.RetailPrice;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
