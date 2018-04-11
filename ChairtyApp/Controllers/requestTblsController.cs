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
    public class requestTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: requestTbls
        public async Task<ActionResult> Index()
        {
            var requestTbls = db.requestTbls.Include(r => r.userTbl);
            return View(await requestTbls.ToListAsync());
        }

        // GET: requestTbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            requestTbl requestTbl = await db.requestTbls.FindAsync(id);
            if (requestTbl == null)
            {
                return HttpNotFound();
            }
            return View(requestTbl);
        }

        // GET: requestTbls/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.userTbls, "userId", "userName");
            return View();
        }

        // POST: requestTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "requestId,probStatment,userId")] requestTbl requestTbl)
        {
            if (ModelState.IsValid)
            {
                db.requestTbls.Add(requestTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.userTbls, "userId", "userName", requestTbl.userId);
            return View(requestTbl);
        }

        // GET: requestTbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            requestTbl requestTbl = await db.requestTbls.FindAsync(id);
            if (requestTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.userTbls, "userId", "userName", requestTbl.userId);
            return View(requestTbl);
        }

        // POST: requestTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "requestId,probStatment,userId")] requestTbl requestTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.userTbls, "userId", "userName", requestTbl.userId);
            return View(requestTbl);
        }

        // GET: requestTbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            requestTbl requestTbl = await db.requestTbls.FindAsync(id);
            if (requestTbl == null)
            {
                return HttpNotFound();
            }
            return View(requestTbl);
        }

        // POST: requestTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            requestTbl requestTbl = await db.requestTbls.FindAsync(id);
            db.requestTbls.Remove(requestTbl);
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
