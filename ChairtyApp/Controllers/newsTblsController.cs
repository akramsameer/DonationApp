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
    public class newsTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: newsTbls
        public async Task<ActionResult> Index()
        {
            return View(await db.newsTbls.ToListAsync());
        }

        // GET: newsTbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newsTbl newsTbl = await db.newsTbls.FindAsync(id);
            if (newsTbl == null)
            {
                return HttpNotFound();
            }
            return View(newsTbl);
        }

        // GET: newsTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: newsTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "newsId,newsDescription,newsImage")] newsTbl newsTbl)
        {
            if (ModelState.IsValid)
            {
                db.newsTbls.Add(newsTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(newsTbl);
        }

        // GET: newsTbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newsTbl newsTbl = await db.newsTbls.FindAsync(id);
            if (newsTbl == null)
            {
                return HttpNotFound();
            }
            return View(newsTbl);
        }

        // POST: newsTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "newsId,newsDescription,newsImage")] newsTbl newsTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newsTbl);
        }

        // GET: newsTbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newsTbl newsTbl = await db.newsTbls.FindAsync(id);
            if (newsTbl == null)
            {
                return HttpNotFound();
            }
            return View(newsTbl);
        }

        // POST: newsTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            newsTbl newsTbl = await db.newsTbls.FindAsync(id);
            db.newsTbls.Remove(newsTbl);
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
