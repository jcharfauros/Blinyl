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
        [Display(Name ="Collection #")]
        public int CollectorsToysId { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage ="There are too many characters in this field"), 
            MinLength(5, ErrorMessage ="Please make the title at least 5 characters")]
        public string ListTitle { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
