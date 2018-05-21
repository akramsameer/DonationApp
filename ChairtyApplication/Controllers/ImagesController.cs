using System.IO;
using System.Web;
using System.Web.Mvc;
using Simple.ImageResizer.MvcExtensions;
using Simple.ImageResizer;

namespace ChairtyApplication.Controllers
{
    public class ImagesController : Controller
    {
        [OutputCache(VaryByParam = "*", Duration = 60 * 60 * 24 * 365)]
        public ImageResult Index(string filename, int w = 0, int h = 0)
        {
            var filepath = Path.Combine(Server.MapPath("~/upload"), filename);
            return new ImageResult(filepath, w, h);
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            byte[] data;
            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            var imageResizer = new ImageResizer(data);
            imageResizer.Resize(800, ImageEncoding.Jpg100);
            imageResizer.SaveToFile(Path.Combine(Server.MapPath("~/upload"), file.FileName));
            return View();
        }
    }

}