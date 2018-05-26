using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;
using ChairtyApplication.Models;
using ChairtyApplication.Models.ViewModels.Admin;
using WebGrease.Css.Extensions;

namespace ChairtyApplication.Controllers
{
    [Authorize]
    public class RequistsController : Controller
    {
        private ChairtyDbEntities db = new ChairtyDbEntities();
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Requists
        public ActionResult Index()
        {
            var ret = new List<RequestViewModel>();
//            ret.Add(new RequestViewModel()
//            {
//                RequiredMoney = 20,
//                BloodType = "A+",
//                NationalId = "054848486",
//                ProblemStatement = "fdjkjfdhjdfkj",
//                Name = "fddddddddddd"
//            });
            db.Requists.ForEach(x =>
            {
                var user = _context.Users.Find(x.UserId);
                ret.Add(new RequestViewModel()
                {
                    Name = user.UserName,
                    BloodType = user.BloodType,
                    NationalId = user.NationalId,
                    ProblemStatement = x.DetailsProblem,
                    RequiredMoney = (double)x.RequireMoney
                } );
            });
            return View(ret);
        }

        // GET: Requists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requist requist = db.Requists.Find(id);
            if (requist == null)
            {
                return HttpNotFound();
            }
            return View(requist);
        }

        // GET: Requists/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password");
            return View();
        }

        // POST: Requists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RequireMoney,DetailsProblem,UserId")] Requist requist)
        {
            if (ModelState.IsValid)
            {
                db.Requists.Add(requist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", requist.UserId);
            return View(requist);
        }

        // GET: Requists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requist requist = db.Requists.Find(id);
            if (requist == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", requist.UserId);
            return View(requist);
        }

        // POST: Requists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RequireMoney,DetailsProblem,UserId")] Requist requist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", requist.UserId);
            return View(requist);
        }

        // GET: Requists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requist requist = db.Requists.Find(id);
            if (requist == null)
            {
                return HttpNotFound();
            }
            return View(requist);
        }

        // POST: Requists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requist requist = db.Requists.Find(id);
            db.Requists.Remove(requist);
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
