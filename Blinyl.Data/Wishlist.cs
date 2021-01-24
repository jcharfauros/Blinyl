using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Data
{
    public class Wishlist
    {
        public Wishlist()
        {
            ToyItem = new HashSet<Toy>();
            //Collector = new HashSet<ApplicationUser>();
        }
        [Key] 
        public int WishId { get; set; }                       
        [ForeignKey(nameof(ToyId))]
        public virtual int? ToyId { get; }        
        public virtual ICollection<Toy> ToyItem { get; set; }
        [ForeignKey("UserId")]        
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }        
        public string WishListTitle { get; set; }        
        public DateTimeOffset CreateUtc { get; set; }        
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
