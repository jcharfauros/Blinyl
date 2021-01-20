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
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Series { get; set; }

        //Julia note: don't really need to know when it was added to DB
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        //public DateTime CreatedUtc { get; set; }
    }
}
