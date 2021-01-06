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
        public int UserId { get; set; }
        [ForeignKey("ToyId")]
        public int ToyId { get; set; }
        [Required]
        [MaxLength(45), MinLength(5)]
        public string WishListTitle { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
