using Blinyl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class WishListItem
    {
        public int WishId { get; set; }
        [Required]
        [MaxLength(45), MinLength(5)]
        [Display(Name = "Wish List Name")]
        public string WishListTitle { get; set; }
        [Display(Name = "Created on")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified on")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public virtual ICollection<Toy> Toys { get; set; }
    }
}
