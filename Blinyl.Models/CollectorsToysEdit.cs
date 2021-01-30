using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blinyl.Models
{
    public class CollectorsToysEdit
    {
        public int CollectorsToysId { get; set; }
        public string Title { get; set; }
        public IEnumerable<SelectListItem> Toys { get; set; }
        public int[] SelectedToyIds { get; set; }
    }
}
