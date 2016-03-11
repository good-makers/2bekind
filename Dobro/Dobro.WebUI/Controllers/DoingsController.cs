using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dobro.Domain.Entities;
using Dobro.WebUI.Models;

namespace Dobro.WebUI.Controllers
{
    public class DoingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Choose(int? id)
        {
            return RedirectToAction("Index");
        }

        // GET: Doings
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Doings.ToList());
        }

        // GET: Doings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doing doing = db.Doings.Find(id);
            if (doing == null)
            {
                return HttpNotFound();
            }
            return View(doing);
        }

        // GET: Doings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoingId,Name,Description,Metro,StartTime,FinishTime")] Doing doing)
        {
            if (ModelState.IsValid)
            {
                db.Doings.Add(doing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doing);
        }

        // GET: Doings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doing doing;
            if ((doing = db.Doings.Find(id)) == null)
            {
                return HttpNotFound();
            }
            return View(doing);
        }

        // POST: Doings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoingId,Name,Description,Metro,StartTime,FinishTime")] Doing doing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doing);
        }

        // GET: Doings/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doing doing = db.Doings.Find(id);
            if (doing == null)
            {
                return HttpNotFound();
            }
            return View(doing);
        }

        // POST: Doings/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")] //переопределение имени для перекидывания на контроллер с другим именем
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doing doing = db.Doings.Find(id);
            db.Doings.Remove(doing);
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
