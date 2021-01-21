using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinyl.Models
{
    public class ImageUploadModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        [Required(ErrorMessage = "Please choose image to upload.")]
        public string File { get; set; }
    }
}
