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
               
        [ForeignKey(nameof(Toy))]
        public int ToyId { get; set; }
        public virtual Toy Toy { get; set; }
        //public virtual ICollection<Toy> Toys { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        //public virtual string UserId { get; }
        [Required][MaxLength(45), MinLength(5)] 
        [Display(Name="Wish List Name")]
        public string WishListTitle { get; set; }
        [Display(Name ="Created on")]
        public DateTimeOffset CreateUtc { get; set; }
        [Display(Name ="Modified on")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
