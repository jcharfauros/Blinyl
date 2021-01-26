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
        //public Wishlist()
        //{
        //    Toys = new HashSet<Toy>();            
        //}
        [Key] 
        public int WishId { get; set; }        
        [ForeignKey("UserId")]        
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }        
        public string WishListTitle { get; set; }        
        public DateTimeOffset CreateUtc { get; set; }        
        public DateTimeOffset ModifiedUtc { get; set; }
        public virtual ICollection<Toy> Toys { get; set; }
    }
}
