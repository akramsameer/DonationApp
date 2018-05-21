using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChairtyApplication.Models;
using ChairtyApplication.Models.ViewModels;
using ChairtyApplication.Models.ViewModels.Admin;
using WebGrease.Css.Extensions;

namespace ChairtyApplication.Controllers
{
    public class DonationsController : Controller
    {
        private ChairtyDbEntities db = new ChairtyDbEntities();

        // GET: Donations
        public ActionResult Index()
        {
            var ret = new List<DonationViewModel>();
//            ret.Add(new DonationViewModel()
//            {
//                DonationMoney = 20,
//                DonatorNationalId = "054848486",
//                DonatorBloodType = "A+",
//                DonatorName = "fddddddddddd"
//            });
            db.Requists.Include(r => r.User).ForEach(x =>
            {
                Debug.Assert(x.RequireMoney != null, "x.RequireMoney != null");
                ret.Add(new DonationViewModel()
                {
                    DonatorName = x.User.UserName,
                    DonatorBloodType = x.User.BloodCategory,
                    DonatorNationalId = x.User.IdentificationNumber,
                    DonationMoney = (double)x.RequireMoney
                });
            });
            return View(ret);
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsCredit,Cost,UserId")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", donation.UserId);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", donation.UserId);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsCredit,Cost,UserId")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", donation.UserId);
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
