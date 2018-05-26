using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChairtyApplication.Models;
using ChairtyApplication.Models.ViewModels.Admin;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Extensions;

namespace ChairtyApplication.Controllers
{
    [Authorize]
    public class RequistsController : Controller
    {
        private ChairtyDbEntities db = new ChairtyDbEntities();
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Requists
        public ActionResult Index()
        {
            var ret = new List<RequestViewModel>();
//            ret.Add(new RequestViewModel()
//            {
//                RequiredMoney = 20,
//                BloodType = "A+",
//                NationalId = "054848486",
//                ProblemStatement = "fdjkjfdhjdfkj",
//                Name = "fddddddddddd"
//            });
            db.Requists.ForEach(x =>
            {
                var user = _context.Users.Find(x.UserId);
                var assinguser = _context.Users.Find(x.UserIdAssign);
                ret.Add(new RequestViewModel()
                {
                    AssignId = (assinguser == null) ? "0": assinguser.Id,
                    AssignUserName = (assinguser == null)?"لم يتم تعين مسئول بعد": assinguser.UserName,
                    Id = x.Id,
                    Name = user.UserName,
                    BloodType = user.BloodType,
                    NationalId = user.NationalId,
                    ProblemStatement = x.DetailsProblem,
                    RequiredMoney = (double)x.RequireMoney
                } );
            });
            int ruleid = _context.Users.Find(User.Identity.GetUserId()).RuleId;
            if(ruleid == 1)
                return View(ret);
            else if (ruleid == 2)
            {
                ret = ret.Where(m => m.AssignId == User.Identity.GetUserId()).ToList();
                return View(ret);
            }

            return RedirectToAction("Login", "Users");
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
        public ActionResult Create(Requist requist)
        {
            if (ModelState.IsValid)
            {
                requist.UserId = User.Identity.GetUserId();
                db.Requists.Add(requist);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
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
            ViewBag.zeroooo = new SelectList(_context.Users.Where(d => d.RuleId == 2), "Id", "UserName", requist.UserIdAssign);
            ViewBag.ruleid = _context.Users.Find(User.Identity.GetUserId()).RuleId;

            string xx = requist.Done.ToString();
            ViewBag.ant = new SelectList(
                new[] {new {Value = "True", Text = "Yes"}, new {Value = "False", Text = "No"}}
                , "Value", "Text", xx
            );
            return View(requist);
        }

        // POST: Requists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Requist requist)
        {
            var ruleid = _context.Users.Find(User.Identity.GetUserId()).RuleId;
            if (ModelState.IsValid)
            {
                
                var fromdb = db.Requists.SingleOrDefault(r => r.Id == requist.Id);
                if (ruleid == 1)
                    fromdb.UserIdAssign = requist.UserIdAssign;
                else
                    fromdb.Done = requist.UserIdAssign == "true";
                db.SaveChanges();
                fromdb = db.Requists.SingleOrDefault(r => r.Id == requist.Id);

                return RedirectToAction("Index");
            }

            ViewBag.zeroooo = new SelectList(_context.Users.Where(d => d.RuleId == 2), "Id", "UserName",requist.UserIdAssign);
            ViewBag.ruleid = ruleid;
            string xx = requist.Done.ToString();
            ViewBag.ant = new SelectList(
                new[] { new { Value = "True", Text = "Yes" }, new { Value = "False", Text = "No" } }
                , "Value", "Text", xx
            );
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
