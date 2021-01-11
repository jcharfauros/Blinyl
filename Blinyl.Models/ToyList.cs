using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class ToyList
    {
        public int ToyId { get; set; }
        [Display(Name ="Date Added")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
