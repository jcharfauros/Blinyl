using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class ImageModel
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(45)]
        public string Description { get; set; }
        [Required]
        public byte[] Image { get; set; }
    }
}
