using Blinyl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blinyl.Models
{
    public class WishListDetail
    {        
        public int WishId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        //public string UserId { get; set; }
        public string WishListTitle { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public virtual IEnumerable<SelectListItem> Toys { get; set; }
    }
}
