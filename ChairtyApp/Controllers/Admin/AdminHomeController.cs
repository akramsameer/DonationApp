using System.Web.Mvc;

namespace ChairtyApp.Controllers.Admin {
    public class AdminHomeController : Controller {
        private const string BaseView = "~/Views/Admin/AdminHome/";
        // GET: adminHome
        public ActionResult Index() {
            return View(BaseView + "Index.cshtml");
        }
    }
}
