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
        [Display(Name = "Wish list name")]
        public string WishListTitle { get; set; }
        [Display(Name = "Wish list Created on")]
        public DateTimeOffset CreateUtc { get; set; }
        [Display(Name = "Wish list Modified on")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public virtual IEnumerable<SelectListItem> Toys { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        //public string UserId { get; set; }
    }
}
