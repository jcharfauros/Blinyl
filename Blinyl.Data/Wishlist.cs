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
        [Key] 
        public int WishId { get; set; }
        [ForeignKey("UserId")]        
        public virtual string UserId { get; }
        [ForeignKey("ToyId")]
        public virtual int ToyId { get; }
        public virtual ICollection<Toy> Toys { get; set; }
        [Required][MaxLength(45), MinLength(5)] 
        public string WishListTitle { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreateUtc { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
