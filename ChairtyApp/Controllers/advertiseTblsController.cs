using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChairtyApp.Models;

namespace ChairtyApp.Controllers
{
    public class advertiseTblsController : Controller
    {
        private chairtyDbEntities db = new chairtyDbEntities();

        // GET: advertiseTbls
        public async Task<ActionResult> Index()
        {
            return View(await db.advertiseTbls.ToListAsync());
        }
        [HttpPost]
        public async Task<JsonResult> UploadFile(string id)
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    string fname = "success";
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/App_Data/Images/"), fname);
                        file.SaveAs(fname); // id
                    }
                    // Returns message that successfully uploaded  
                    return Json(fname);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        // GET: advertiseTbls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            advertiseTbl advertiseTbl = await db.advertiseTbls.FindAsync(id);
            if (advertiseTbl == null)
            {
                return HttpNotFound();
            }
            return View(advertiseTbl);
        }

        // GET: advertiseTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: advertiseTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "advText")] advertiseTbl advertiseTbl)
        {
            if (ModelState.IsValid)
            {
                db.advertiseTbls.Add(advertiseTbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(advertiseTbl);
        }

        // GET: advertiseTbls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            advertiseTbl advertiseTbl = await db.advertiseTbls.FindAsync(id);
            if (advertiseTbl == null)
            {
                return HttpNotFound();
            }
            return View(advertiseTbl);
        }

        // POST: advertiseTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "adverId,advText,advImage")] advertiseTbl advertiseTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertiseTbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(advertiseTbl);
        }

        // GET: advertiseTbls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            advertiseTbl advertiseTbl = await db.advertiseTbls.FindAsync(id);
            if (advertiseTbl == null)
            {
                return HttpNotFound();
            }
            return View(advertiseTbl);
        }

        // POST: advertiseTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            advertiseTbl advertiseTbl = await db.advertiseTbls.FindAsync(id);
            db.advertiseTbls.Remove(advertiseTbl);
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
