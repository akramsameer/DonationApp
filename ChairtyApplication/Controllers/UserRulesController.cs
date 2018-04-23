using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChairtyApplication.Models;

namespace ChairtyApplication.Controllers
{
    public class UserRulesController : Controller
    {
        private ChairtyDbEntities db = new ChairtyDbEntities();

        // GET: UserRules
        public ActionResult Index()
        {
            return View(db.UserRules.ToList());
        }

        // GET: UserRules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRule userRule = db.UserRules.Find(id);
            if (userRule == null)
            {
                return HttpNotFound();
            }
            return View(userRule);
        }

        // GET: UserRules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RuleName")] UserRule userRule)
        {
            if (ModelState.IsValid)
            {
                db.UserRules.Add(userRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRule);
        }

        // GET: UserRules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRule userRule = db.UserRules.Find(id);
            if (userRule == null)
            {
                return HttpNotFound();
            }
            return View(userRule);
        }

        // POST: UserRules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RuleName")] UserRule userRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRule);
        }

        // GET: UserRules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRule userRule = db.UserRules.Find(id);
            if (userRule == null)
            {
                return HttpNotFound();
            }
            return View(userRule);
        }

        // POST: UserRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRule userRule = db.UserRules.Find(id);
            db.UserRules.Remove(userRule);
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
