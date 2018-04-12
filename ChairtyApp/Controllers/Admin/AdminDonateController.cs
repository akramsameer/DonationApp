using System.Web.Mvc;

namespace ChairtyApp.Controllers.Admin {
    public class AdminDonateController : Controller {
        private const string BaseView = "~/Views/Admin/AdminDonate/";

        // GET: adminHome
        public ActionResult Index() {
            return View(BaseView + "Index.cshtml");
        }
    }
}
