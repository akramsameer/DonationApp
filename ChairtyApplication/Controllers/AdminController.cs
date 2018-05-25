using System;
using System.Linq;
using System.Web.Mvc;
using ChairtyApplication.Models;
using ChairtyApplication.Models.ViewModels.Admin;

namespace ChairtyApplication.Controllers
{
    public class AdminController : Controller
    {
        private ChairtyDbEntities db = new ChairtyDbEntities();

        // GET: Admin
        public ActionResult Index()
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);

            var requestsNumber = db.Requists.Count();
            var donationsNumber = db.Donations.Count();
            var projectsDone = db.Advertises.Count();
            var messagesNumber = db.Videos.Count();
            var ret = new DashBoardVm
            {
                RequestsNumber = requestsNumber,
                DonationsNumber = donationsNumber,
                ProjectsDone = projectsDone,
                MessagesNumber = messagesNumber
            };

            return View(ret);
        }
    }
}