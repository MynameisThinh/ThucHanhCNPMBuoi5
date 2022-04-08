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
    public class CTDATHANGsController : Controller
    {
        private QLBANSACHEntities db = new QLBANSACHEntities();

        // GET: CTDATHANGs
        public ActionResult Index()
        {
            var cTDATHANGs = db.CTDATHANGs.Include(c => c.DONDATHANG).Include(c => c.SACH1);
            return View(cTDATHANGs.ToList());
        }

        // GET: CTDATHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDATHANG cTDATHANG = db.CTDATHANGs.Find(id);
            if (cTDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(cTDATHANG);
        }

        // GET: CTDATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.SoDH = new SelectList(db.DONDATHANGs, "SoDH", "Tennguoinhan");
            ViewBag.SoDH = new SelectList(db.SACH1, "Masach", "Tensach");
            return View();
        }

        // POST: CTDATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoDH,Masach,Soluong,Dongia,Thanhtien")] CTDATHANG cTDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.CTDATHANGs.Add(cTDATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SoDH = new SelectList(db.DONDATHANGs, "SoDH", "Tennguoinhan", cTDATHANG.SoDH);
            ViewBag.SoDH = new SelectList(db.SACH1, "Masach", "Tensach", cTDATHANG.SoDH);
            return View(cTDATHANG);
        }

        // GET: CTDATHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDATHANG cTDATHANG = db.CTDATHANGs.Find(id);
            if (cTDATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.SoDH = new SelectList(db.DONDATHANGs, "SoDH", "Tennguoinhan", cTDATHANG.SoDH);
            ViewBag.SoDH = new SelectList(db.SACH1, "Masach", "Tensach", cTDATHANG.SoDH);
            return View(cTDATHANG);
        }

        // POST: CTDATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoDH,Masach,Soluong,Dongia,Thanhtien")] CTDATHANG cTDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTDATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SoDH = new SelectList(db.DONDATHANGs, "SoDH", "Tennguoinhan", cTDATHANG.SoDH);
            ViewBag.SoDH = new SelectList(db.SACH1, "Masach", "Tensach", cTDATHANG.SoDH);
            return View(cTDATHANG);
        }

        // GET: CTDATHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDATHANG cTDATHANG = db.CTDATHANGs.Find(id);
            if (cTDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(cTDATHANG);
        }

        // POST: CTDATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTDATHANG cTDATHANG = db.CTDATHANGs.Find(id);
            db.CTDATHANGs.Remove(cTDATHANG);
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
