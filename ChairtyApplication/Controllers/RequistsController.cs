﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChairtyApplication.Models;

namespace ChairtyApplication.Controllers
{
    public class RequistsController : Controller
    {
        private ChairtyDbEntities db = new ChairtyDbEntities();

        // GET: Requists
        public ActionResult Index()
        {
            var requists = db.Requists.Include(r => r.User);
            return View(requists.ToList());
        }

        // GET: Requists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requist requist = db.Requists.Find(id);
            if (requist == null)
            {
                return HttpNotFound();
            }
            return View(requist);
        }

        // GET: Requists/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password");
            return View();
        }

        // POST: Requists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RequireMoney,DetailsProblem,UserId")] Requist requist)
        {
            if (ModelState.IsValid)
            {
                db.Requists.Add(requist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", requist.UserId);
            return View(requist);
        }

        // GET: Requists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requist requist = db.Requists.Find(id);
            if (requist == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", requist.UserId);
            return View(requist);
        }

        // POST: Requists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RequireMoney,DetailsProblem,UserId")] Requist requist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", requist.UserId);
            return View(requist);
        }

        // GET: Requists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requist requist = db.Requists.Find(id);
            if (requist == null)
            {
                return HttpNotFound();
            }
            return View(requist);
        }

        // POST: Requists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requist requist = db.Requists.Find(id);
            db.Requists.Remove(requist);
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
