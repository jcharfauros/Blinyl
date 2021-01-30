using Blinyl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class Wishlist
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Toy> Toys { get; set; }
    }
}
