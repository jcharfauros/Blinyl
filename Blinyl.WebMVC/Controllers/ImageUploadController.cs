using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blinyl.WebMVC.Controllers
{
    public class ImageUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //Method to get image details from HttpPostedFileBase class

                    if (image != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedImages"), Path.GetFileName(image.FileName));
                        image.SaveAs(path);
                    }
                    ViewBag.FileStatus = "Image uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while image uploading."; ;
                }
            }
            return View("Index");
        }
    }
}