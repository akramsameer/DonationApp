using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChairtyApp.Models;

namespace ChairtyApp.Controllers
{
    public class userTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: userTbls
        public async Task<ActionResult> Index()
        {
            var userTbls = db.userTbls.Include(u => u.ruleTbl);
            return View(await userTbls.ToListAsync());
        }



       

        // GET: userTbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTbl userTbl = await db.userTbls.FindAsync(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // GET: userTbls/Create
        public ActionResult Create()
        {
            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName");
            return View();
        }
        public ActionResult LoginUser()
        {
            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName");
            return View();
        }

        // POST: userTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "userId,userName,phoneNum,Magnitude,Landitude,creditNum,creditType,ruleId,Name,Email,Password")] userTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                userTbl.userName = "";
                userTbl.Landitude = 0.0f;
                userTbl.Magnitude = 0.0f;
                // assing User role 2 ==> User
                userTbl.ruleId = 2;

                db.userTbls.Add(userTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName", userTbl.ruleId);
            return View(userTbl);
        }

        // GET: userTbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTbl userTbl = await db.userTbls.FindAsync(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName", userTbl.ruleId);
            return View(userTbl);
        }

        // POST: userTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "userId,userName,phoneNum,Magnitude,Landitude,creditNum,creditType,ruleId,Name,Email,Password")] userTbl userTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName", userTbl.ruleId);
            return View(userTbl);
        }

        [HttpPost]
        public  ActionResult LoginUser([Bind(Include = "Email,Password")] userTbl userTbl)
        {
            var user = db.userTbls.FirstOrDefault(x => x.Email == userTbl.Email);
            if (user == null)
            {
                ViewBag.Errors = "Password was incorrect";
                return View("LoginUser");
            }

            if (user.Password == userTbl.Password)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Errors = "Password was incorrect";
                return View("LoginUser");
            }
        }

        // GET: userTbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTbl userTbl = await db.userTbls.FindAsync(id);
            if (userTbl == null)
            {
                return HttpNotFound();
            }
            return View(userTbl);
        }

        // POST: userTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            userTbl userTbl = await db.userTbls.FindAsync(id);
            db.userTbls.Remove(userTbl);
            await db.SaveChangesAsync();
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
