using Blinyl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blinyl.WebMVC.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            List<ImageModel> toyImage = GetImage();
            return View(toyImage);
        }

        [HttpPost]
        public ActionResult Index(int? ImageId)
        {
            List<ImageModel> toyImage = GetImage();
            ImageModel image = toyImage.Find(p => p.Id == ImageId);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(toyImage);
        }

        private List<ImageCreate> GetImage()
        {

        }
    }
}