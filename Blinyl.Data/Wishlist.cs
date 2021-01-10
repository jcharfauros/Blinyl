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
        [Key] public int WishId { get; set; }
        [ForeignKey("UserId")]        
        public virtual string UserId { get; }
        [ForeignKey("ToyId")]
        public virtual int ToyId { get; set; }
        public virtual ICollection<Toy> Toys { get; set; }
        [Required][MaxLength(45), MinLength(5)] public string WishListTitle { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
