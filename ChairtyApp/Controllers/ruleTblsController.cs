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
    public class ruleTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: ruleTbls
        public async Task<ActionResult> Index()
        {
            return View(await db.ruleTbls.ToListAsync());
        }

        // GET: ruleTbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ruleTbl ruleTbl = await db.ruleTbls.FindAsync(id);
            if (ruleTbl == null)
            {
                return HttpNotFound();
            }
            return View(ruleTbl);
        }

        // GET: ruleTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ruleTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ruleId,ruleName")] ruleTbl ruleTbl)
        {
            if (ModelState.IsValid)
            {
                db.ruleTbls.Add(ruleTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ruleTbl);
        }

        // GET: ruleTbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ruleTbl ruleTbl = await db.ruleTbls.FindAsync(id);
            if (ruleTbl == null)
            {
                return HttpNotFound();
            }
            return View(ruleTbl);
        }

        // POST: ruleTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ruleId,ruleName")] ruleTbl ruleTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruleTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ruleTbl);
        }

        // GET: ruleTbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ruleTbl ruleTbl = await db.ruleTbls.FindAsync(id);
            if (ruleTbl == null)
            {
                return HttpNotFound();
            }
            return View(ruleTbl);
        }

        // POST: ruleTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ruleTbl ruleTbl = await db.ruleTbls.FindAsync(id);
            db.ruleTbls.Remove(ruleTbl);
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
