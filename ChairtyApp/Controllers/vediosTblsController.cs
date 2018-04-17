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
using ChairtyApp.Models.ViewModels;

namespace ChairtyApp.Controllers
{
    public class vediosTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: vediosTbls
        public async Task<ActionResult> Index()
        {
            var lst = await db.vediosTbls.ToListAsync();
            VedioViewModel vm = new VedioViewModel()
            {
                ListOfVedios = lst
            };

            return View(vm);
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
        public async Task<ActionResult> Create(VedioViewModel vedioViewModel)
        {
            vediosTbl vediosTbl = vedioViewModel.Vedio;
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
            return PartialView("VedioEditModal", vediosTbl);
        }

        // POST: vediosTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit(int id, string vedioUrl)
        {
            var vedio = await db.vediosTbls.SingleOrDefaultAsync(x => x.vedioId == id);
            if (vedio != null)
            {
                vedio.vedioUrl = vedioUrl;
                await db.SaveChangesAsync();
                return Json(vedio);

            }
            
            return View();
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
