using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class CollectorsToysDetail
    {
        public int CollectorsToysId { get; set; }
        [Display(Name=("User"))] //is this right? I want the user's name to be displayed
        public int UserId { get; set; }        
        [Display(Name ="Collection Created on")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Collection Modified on")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
