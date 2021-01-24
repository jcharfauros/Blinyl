﻿using System;
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
    }
}
