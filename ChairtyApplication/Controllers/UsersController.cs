using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChairtyApplication.Models;
using HomeCinema.Service;
using HomeCinema.Service.Abstract;

namespace ChairtyApplication.Controllers
{
    public class UsersController : Controller
    {
        private ChairtyDbEntities db = new ChairtyDbEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Credit).Include(u => u.UserRule);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        // GET: Users/Create
        public ActionResult CreateSubAdmin()
        {
            ViewBag.CreditId = new SelectList(db.Credits, "Id", "TypeName");

            ViewBag.RuleId = new SelectList(db.UserRules, "Id", "RuleName");
            return View(new User());
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.CreditId = new SelectList(db.Credits, "Id", "TypeName");

            ViewBag.RuleId = new SelectList(db.UserRules, "Id", "RuleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Password,Email,UserName,Magnitude,Landitude,CreditNumber,CreditId,RuleId,IdentificationNumber,BloodCategory")] User user)
        {
            var encrypt = new EncryptionService();

            if (ModelState.IsValid)
            {
                var pass = encrypt.EncryptPassword(user.Password, "WQFNNm43TNyxIxBWxnWlzg==");
                user.Password = pass;
                if (user.RuleId == null)
                {
                    user.RuleId = 3;    // normal user
                }

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreditId = new SelectList(db.Credits, "Id", "TypeName", user.CreditId);
            ViewBag.RuleId = new SelectList(db.UserRules, "Id", "RuleName", user.RuleId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Password,Email")] User user)
        {
            var encrypt = new EncryptionService();


            var pass = encrypt.EncryptPassword(user.Password, "WQFNNm43TNyxIxBWxnWlzg==");
            user.Password = pass;


            User valid = db.Users.SingleOrDefault(x => x.Password == pass && x.Email == user.Email);
            if (valid == null)
            {
                ViewBag.CreditId = new SelectList(db.Credits, "Id", "TypeName", user.CreditId);
                ViewBag.RuleId = new SelectList(db.UserRules, "Id", "RuleName", user.RuleId);
                return View(user);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreditId = new SelectList(db.Credits, "Id", "TypeName", user.CreditId);
            ViewBag.RuleId = new SelectList(db.UserRules, "Id", "RuleName", user.RuleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password,Email,UserName,Magnitude,Landitude,CreditNumber,CreditId,RuleId,IdentificationNumber,BloodCategory")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreditId = new SelectList(db.Credits, "Id", "TypeName", user.CreditId);
            ViewBag.RuleId = new SelectList(db.UserRules, "Id", "RuleName", user.RuleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
