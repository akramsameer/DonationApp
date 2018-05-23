using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ImageResizer;
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

        [HttpPost]
        public JsonResult UploadFile()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    string fname = "success";
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        var item = new ImageJob(file, $"~/uploads/{fname}", new ResizeSettings()
                        {
                            MaxWidth = 400
                        });
                        item.CreateParentDirectory = true;
                        item.Build();
                        fname = $"~/uploads/{fname}";
                    }
                    // Returns message that successfully uploaded  
                    return Json(fname);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
    }

}