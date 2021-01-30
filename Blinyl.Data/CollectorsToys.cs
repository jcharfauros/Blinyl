using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blinyl.Data
{
    public class CollectorsToys
    {
        [Key] 
        public int CollectorsToysId { get; set; }
        public Guid OwnerId { get; set; }        
        [Required]
        public string Title { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreateUtc { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; } 
        public virtual IEnumerable<SelectListItem> Toys { get; set; }
    }
}
