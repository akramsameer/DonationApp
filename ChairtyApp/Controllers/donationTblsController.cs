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
    public class donationTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: donationTbls
        public async Task<ActionResult> Index()
        {
            var donationTbls = db.donationTbls.Include(d => d.userTbl);
            return View(await donationTbls.ToListAsync());
        }

        // GET: donationTbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donationTbl donationTbl = await db.donationTbls.FindAsync(id);
            if (donationTbl == null)
            {
                return HttpNotFound();
            }
            return View(donationTbl);
        }

        // GET: donationTbls/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.userTbls, "userId", "userName");
            return View();
        }

        // POST: donationTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "donationId,isCredit,costOfDonation,userId")] donationTbl donationTbl)
        {
            if (ModelState.IsValid)
            {
                db.donationTbls.Add(donationTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.userTbls, "userId", "userName", donationTbl.userId);
            return View(donationTbl);
        }

        // GET: donationTbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donationTbl donationTbl = await db.donationTbls.FindAsync(id);
            if (donationTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.userTbls, "userId", "userName", donationTbl.userId);
            return View(donationTbl);
        }

        // POST: donationTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "donationId,isCredit,costOfDonation,userId")] donationTbl donationTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.userTbls, "userId", "userName", donationTbl.userId);
            return View(donationTbl);
        }

        // GET: donationTbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donationTbl donationTbl = await db.donationTbls.FindAsync(id);
            if (donationTbl == null)
            {
                return HttpNotFound();
            }
            return View(donationTbl);
        }

        // POST: donationTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            donationTbl donationTbl = await db.donationTbls.FindAsync(id);
            db.donationTbls.Remove(donationTbl);
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
