﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Data
{
    public class ToyImage
    {
        [Key]
        public int ImageId { get; set; }
        [ForeignKey("ToyId")]
        public int ToyId { get; set; }
        [Required]
        [MaxLength(45), MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }
    }
}
