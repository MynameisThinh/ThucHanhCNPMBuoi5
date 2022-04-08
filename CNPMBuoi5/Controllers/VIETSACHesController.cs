using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPMBuoi5.Models;

namespace CNPMBuoi5.Controllers
{
    public class VIETSACHesController : Controller
    {
        private QLBANSACHEntities db = new QLBANSACHEntities();

        // GET: VIETSACHes
        public ActionResult Index()
        {
            var vIETSACHes = db.VIETSACHes.Include(v => v.SACH1).Include(v => v.TACGIA);
            return View(vIETSACHes.ToList());
        }

        // GET: VIETSACHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIETSACH vIETSACH = db.VIETSACHes.Find(id);
            if (vIETSACH == null)
            {
                return HttpNotFound();
            }
            return View(vIETSACH);
        }

        // GET: VIETSACHes/Create
        public ActionResult Create()
        {
            ViewBag.Masach = new SelectList(db.SACH1, "Masach", "Tensach");
            ViewBag.MaTG = new SelectList(db.TACGIAs, "MaTG", "TenTG");
            return View();
        }

        // POST: VIETSACHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTG,Masach,Vaitro")] VIETSACH vIETSACH)
        {
            if (ModelState.IsValid)
            {
                db.VIETSACHes.Add(vIETSACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Masach = new SelectList(db.SACH1, "Masach", "Tensach", vIETSACH.Masach);
            ViewBag.MaTG = new SelectList(db.TACGIAs, "MaTG", "TenTG", vIETSACH.MaTG);
            return View(vIETSACH);
        }

        // GET: VIETSACHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIETSACH vIETSACH = db.VIETSACHes.Find(id);
            if (vIETSACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.Masach = new SelectList(db.SACH1, "Masach", "Tensach", vIETSACH.Masach);
            ViewBag.MaTG = new SelectList(db.TACGIAs, "MaTG", "TenTG", vIETSACH.MaTG);
            return View(vIETSACH);
        }

        // POST: VIETSACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTG,Masach,Vaitro")] VIETSACH vIETSACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIETSACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Masach = new SelectList(db.SACH1, "Masach", "Tensach", vIETSACH.Masach);
            ViewBag.MaTG = new SelectList(db.TACGIAs, "MaTG", "TenTG", vIETSACH.MaTG);
            return View(vIETSACH);
        }

        // GET: VIETSACHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIETSACH vIETSACH = db.VIETSACHes.Find(id);
            if (vIETSACH == null)
            {
                return HttpNotFound();
            }
            return View(vIETSACH);
        }

        // POST: VIETSACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VIETSACH vIETSACH = db.VIETSACHes.Find(id);
            db.VIETSACHes.Remove(vIETSACH);
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
