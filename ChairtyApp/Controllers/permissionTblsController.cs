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
    public class permissionTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: permissionTbls
        public async Task<ActionResult> Index()
        {
            var permissionTbls = db.permissionTbls.Include(p => p.ruleTbl);
            return View(await permissionTbls.ToListAsync());
        }

        // GET: permissionTbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permissionTbl permissionTbl = await db.permissionTbls.FindAsync(id);
            if (permissionTbl == null)
            {
                return HttpNotFound();
            }
            return View(permissionTbl);
        }

        // GET: permissionTbls/Create
        public ActionResult Create()
        {
            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName");
            return View();
        }

        // POST: permissionTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "perId,perName,ruleId")] permissionTbl permissionTbl)
        {
            if (ModelState.IsValid)
            {
                db.permissionTbls.Add(permissionTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName", permissionTbl.ruleId);
            return View(permissionTbl);
        }

        // GET: permissionTbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permissionTbl permissionTbl = await db.permissionTbls.FindAsync(id);
            if (permissionTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName", permissionTbl.ruleId);
            return View(permissionTbl);
        }

        // POST: permissionTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "perId,perName,ruleId")] permissionTbl permissionTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissionTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ruleId = new SelectList(db.ruleTbls, "ruleId", "ruleName", permissionTbl.ruleId);
            return View(permissionTbl);
        }

        // GET: permissionTbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permissionTbl permissionTbl = await db.permissionTbls.FindAsync(id);
            if (permissionTbl == null)
            {
                return HttpNotFound();
            }
            return View(permissionTbl);
        }

        // POST: permissionTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            permissionTbl permissionTbl = await db.permissionTbls.FindAsync(id);
            db.permissionTbls.Remove(permissionTbl);
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
