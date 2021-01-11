﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class CollectorsToysCreate
    {
        [Required][MaxLength(50), MinLength(5)]
        [Display(Name ="Collection Title")]
        public string Title { get; set; }
        //public virtual ICollection<Toy> Toys { get; set; }
    }
}