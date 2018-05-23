﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChairtyApplication.Models;
using ChairtyApplication.Models.ViewModels.Admin;

namespace ChairtyApplication.Controllers
{
    public class AdvertisesController : Controller
    {
        private ChairtyDbEntities db = new ChairtyDbEntities();

        // GET: Advertises
        public ActionResult Index()
        {
            return View(db.Advertises.ToList());
        }

        // GET: Advertises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertises.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // GET: Advertises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advertises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvertiseVm adv)
        {
            if (ModelState.IsValid)
            {
                var advertise = new Advertise()
                {
                    Image = adv.Image,
                    Text = adv.Text
                };
                db.Advertises.Add(advertise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adv);
        }

        // GET: Advertises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertises.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            var vm = new AdvertiseVm()
            {
                Image = advertise.Image,
                Id = advertise.Id,
                Text = advertise.Text
            };
            return View(vm);
        }

        // POST: Advertises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdvertiseVm adv)
        {
            if (ModelState.IsValid)
            {
                var advertise = new Advertise()
                {
                    Image = adv.Image,
                    Text = adv.Text,
                    Id = adv.Id
                };
                db.Entry(advertise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adv);
        }

        // GET: Advertises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertise advertise = db.Advertises.Find(id);
            if (advertise == null)
            {
                return HttpNotFound();
            }
            return View(advertise);
        }

        // POST: Advertises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertise advertise = db.Advertises.Find(id);
            db.Advertises.Remove(advertise);
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
