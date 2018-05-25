using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ChairtyApplication.Models;
using ChairtyApplication.Models.ViewModels.Admin;

namespace ChairtyApplication.Controllers
{
    public class HomeController : Controller
    {
        ChairtyDbEntities db = new ChairtyDbEntities();
        public ActionResult Index()
        {
            var videos = db.Videos.ToList();
            var advertises = db.Advertises.ToList();
            var newses = db.News.ToList();
            var ret = new HomeVm
            {
                Videos = videos,
                Advertises = advertises,
                News = newses
            };
            return View(ret);
        }

        [HttpPost]
        public void Contact(ContactU vm)
        {
            db.ContactUs.Add(vm);
            db.SaveChanges();
        }
        public string About()
        {
            var aboutU = db.AboutUs.FirstOrDefault();

            if (aboutU != null) return aboutU.Description;
            db.AboutUs.Add(new AboutU
            {
                Description = "تعريف عن الدكتور موسس الجمعيةتعريف عن الدكتور موسس الجمعيةتعريف عن الدكتور موسس الجمعيةتعريف عن الدكتور موسس الجمعيةتعريف\r\n                        عن الدكتور موسس الجمعيةتعريف عن الدكتور موسس الجمعية\r\n"
            });
            db.SaveChanges();
            aboutU = db.AboutUs.First();
            return aboutU.Description;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}