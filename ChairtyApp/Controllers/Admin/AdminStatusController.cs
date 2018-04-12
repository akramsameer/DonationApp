using System.Web.Mvc;

namespace ChairtyApp.Controllers.Admin {
    public class AdminStatusController : Controller {
        private const string BaseView = "~/Views/Admin/AdminStatus/";
        // GET: adminHome
        public ActionResult Index() {
            return View(BaseView + "index.cshtml");
        }
    }
}
