﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Data
{
    public class Toy
    {
        [Key] public int ToyId { get; set; }
        [Required][MaxLength(50), MinLength(5)] public string Name { get; set; }
        [Required][MaxLength(50), MinLength(5)] public string Brand { get; set; }
        [Required][MaxLength(80), MinLength(5)] public string Series { get; set; }
        [MaxLength(50)] public string Artist { get; set; }
        [Required][MaxLength(8000), MinLength(5)] public string Description { get; set; }
        [Required] public int ReleaseYear { get; set; }
        public decimal RetailPrice { get; set; }
        public virtual Toy Toys { get; set; }
    }
}
