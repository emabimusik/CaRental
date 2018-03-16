using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static OisisCarRental.Models.ApplicationUser;

namespace OisisCarRental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult SpecialOffer()
        {
            ViewBag.Message = "This is special offer";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                String userId = User.Identity.GetUserId();
                // if no user found
                if (userId == null)
                {
                    string filename = HttpContext.Server.MapPath("@/~/Images/noImg.png");
                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(filename);
                    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    long imageFileLength = fileInfo.Length;
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "/image/png");

                }
                // if there is  a user
                var DbUser = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = DbUser.Users.Where(x => x.Id == userId).FirstOrDefault();
                return new FileContentResult(userImage.UserPhoto, "image/jpeg");

            }
            else
            {
                string filename = HttpContext.Server.MapPath(@"~/Images/noImg.png");
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(filename);
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                long imageFileLength = fileInfo.Length;
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "/image/png");


            }
 
        }
    }
}