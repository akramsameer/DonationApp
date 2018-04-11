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
    public class vediosTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: vediosTbls
        public async Task<ActionResult> Index()
        {
            return View(await db.vediosTbls.ToListAsync());
        }

        // GET: vediosTbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vediosTbl vediosTbl = await db.vediosTbls.FindAsync(id);
            if (vediosTbl == null)
            {
                return HttpNotFound();
            }
            return View(vediosTbl);
        }

        // GET: vediosTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vediosTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "vedioId,vedioUrl")] vediosTbl vediosTbl)
        {
            if (ModelState.IsValid)
            {
                db.vediosTbls.Add(vediosTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vediosTbl);
        }

        // GET: vediosTbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vediosTbl vediosTbl = await db.vediosTbls.FindAsync(id);
            if (vediosTbl == null)
            {
                return HttpNotFound();
            }
            return View(vediosTbl);
        }

        // POST: vediosTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "vedioId,vedioUrl")] vediosTbl vediosTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vediosTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vediosTbl);
        }

        // GET: vediosTbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vediosTbl vediosTbl = await db.vediosTbls.FindAsync(id);
            if (vediosTbl == null)
            {
                return HttpNotFound();
            }
            return View(vediosTbl);
        }

        // POST: vediosTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            vediosTbl vediosTbl = await db.vediosTbls.FindAsync(id);
            db.vediosTbls.Remove(vediosTbl);
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
