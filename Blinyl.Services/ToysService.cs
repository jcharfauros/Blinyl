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
                                    Name = e.Name
                                }
                         );
                return query.ToArray();
            }
        }
    }
}
