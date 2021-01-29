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
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        //public string UserId { get; set; }
        //[ForeignKey(nameof(ToyId))]         
        //public virtual int? ToyId { get; }                
        [Required]
        public string Title { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreateUtc { get; set; }
        [Display(Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; } //what's the difference between DateTime vs DateTimeOffSet
        public virtual IEnumerable<SelectListItem> Toys { get; set; }
    }
}
