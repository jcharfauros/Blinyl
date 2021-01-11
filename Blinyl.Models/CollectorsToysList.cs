using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class CollectorsToysList
    {
        public int CollectorsToysId { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage ="There are too many characters in this field"), 
            MinLength(5, ErrorMessage ="Please make the title at least 5 characters")]
        public string ListTitle { get; set; }

        //How to add the toys in the colleciton
        //public virtual ICollection<Toy> Toys { get; set; }
    }
}
