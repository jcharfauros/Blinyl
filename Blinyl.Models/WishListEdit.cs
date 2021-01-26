using Blinyl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class WishListEdit
    {
        public int WishId { get; set; }
        [ForeignKey(nameof(ToyId))]
        public virtual int? ToyId { get; }
        //public virtual Toy Toy { get; set; }
        //public virtual ICollection<Toy> ToyItem { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string WishListTitle { get; set; }

    }
}
