using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChairtyApp.Controllers.Admin {
    public class ChartsController : Controller {
        private const string BaseView = "~/Views/Admin/Charts/";
        // GET: Charts
        public ActionResult Index() {
            return View(BaseView + "index.cshtml");
        }
    }
}