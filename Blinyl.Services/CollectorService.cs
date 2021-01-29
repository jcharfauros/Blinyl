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
    public class CollectorService
    {
        private readonly Guid _userId;
        public CollectorService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateClist(CollectorsToysCreate model)
        {
            var entity =
                new CollectorsToys()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Toys = model.Toys
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CollectorsToys.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Helper method for CollectorList
        public IEnumerable<SelectListItem> GetCListMultiSelect()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.CollectorsToys.Select(collector => new SelectListItem
                    {
                        Text = collector.Title,
                        Value = collector.CollectorsToysId.ToString(),
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<CollectorsToysList> GetCList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var collectorLists =
                    ctx
                        .CollectorsToys
                        .Select(c => new CollectorsToysList()
                        {
                            CollectorsToysId = c.CollectorsToysId,
                            ListTitle = c.Title

                        });

                return collectorLists.ToList();
            }
        }

        public CollectorsToysDetail GetCListById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CollectorsToys
                        .Single(c => c.CollectorsToysId == id && c.OwnerId == _userId);
                return
                    new CollectorsToysDetail
                    {
                        CollectorsToysId = entity.CollectorsToysId,
                        Title = entity.Title
                    };
            }
        }

        public bool UpdateCollectorlist(CollectorsToysEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CollectorsToys
                        .Single(c => c.CollectorsToysId == model.CollectorsToysId && c.OwnerId == _userId);

                entity.Title = model.Title;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCollectorlist(int collectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CollectorsToys
                        .Single(c => c.CollectorsToysId == collectId && c.OwnerId == _userId);

                ctx.CollectorsToys.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
