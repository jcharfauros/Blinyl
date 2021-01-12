using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Data
{
    public class Toy
    {
        [Key] 
        public int ToyId { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Brand { get; set; }
        [Required] 
        public string Series { get; set; }
        public string Artist { get; set; }
        [Required] 
        public string Description { get; set; }
        [Required] 
        public int ReleaseYear { get; set; }
        public decimal RetailPrice { get; set; }
        public virtual Toy Toys { get; set; }
    }
}
