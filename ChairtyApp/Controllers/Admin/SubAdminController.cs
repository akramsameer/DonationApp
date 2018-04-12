using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChairtyApp.Controllers.Admin {
    public class SubAdminController : Controller {
        private const string BaseView = "~/Views/Admin/SubAdmin/";
        // GET: SubAdmin
        public ActionResult Index() {
            return View(BaseView + "index.cshtml");
        }
    }
}