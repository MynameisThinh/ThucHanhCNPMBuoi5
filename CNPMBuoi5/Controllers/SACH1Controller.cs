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
    public class SACH1Controller : Controller
    {
        private QLBANSACHEntities db = new QLBANSACHEntities();

        // GET: SACH1
        public ActionResult Index()
        {
            var sACH1 = db.SACH1.Include(s => s.CHUDE).Include(s => s.NHAXUATBAN);
            return View(sACH1.ToList());
        }

        // GET: SACH1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH1 sACH1 = db.SACH1.Find(id);
            if (sACH1 == null)
            {
                return HttpNotFound();
            }
            return View(sACH1);
        }

        // GET: SACH1/Create
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB");
            return View();
        }

        // POST: SACH1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masach,Tensach,Donvitinh,Dongia,Mota,Hinhminhhoa,MaCD,MaNXB,Ngaycapnhat,Soluongban,solanxem")] SACH1 sACH1)
        {
            if (ModelState.IsValid)
            {
                db.SACH1.Add(sACH1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe", sACH1.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB", sACH1.MaNXB);
            return View(sACH1);
        }

        // GET: SACH1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH1 sACH1 = db.SACH1.Find(id);
            if (sACH1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe", sACH1.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB", sACH1.MaNXB);
            return View(sACH1);
        }

        // POST: SACH1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masach,Tensach,Donvitinh,Dongia,Mota,Hinhminhhoa,MaCD,MaNXB,Ngaycapnhat,Soluongban,solanxem")] SACH1 sACH1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe", sACH1.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB", sACH1.MaNXB);
            return View(sACH1);
        }

        // GET: SACH1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH1 sACH1 = db.SACH1.Find(id);
            if (sACH1 == null)
            {
                return HttpNotFound();
            }
            return View(sACH1);
        }

        // POST: SACH1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SACH1 sACH1 = db.SACH1.Find(id);
            db.SACH1.Remove(sACH1);
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
