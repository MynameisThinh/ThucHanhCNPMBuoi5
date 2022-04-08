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
    public class QUANGCAOsController : Controller
    {
        private QLBANSACHEntities db = new QLBANSACHEntities();

        // GET: QUANGCAOs
        public ActionResult Index()
        {
            return View(db.QUANGCAOs.ToList());
        }

        // GET: QUANGCAOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO qUANGCAO = db.QUANGCAOs.Find(id);
            if (qUANGCAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANGCAO);
        }

        // GET: QUANGCAOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QUANGCAOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,TenCty,Hinhminhhoa,Href,Ngaybatdau,Ngayhethan")] QUANGCAO qUANGCAO)
        {
            if (ModelState.IsValid)
            {
                db.QUANGCAOs.Add(qUANGCAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUANGCAO);
        }

        // GET: QUANGCAOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO qUANGCAO = db.QUANGCAOs.Find(id);
            if (qUANGCAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANGCAO);
        }

        // POST: QUANGCAOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,TenCty,Hinhminhhoa,Href,Ngaybatdau,Ngayhethan")] QUANGCAO qUANGCAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUANGCAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUANGCAO);
        }

        // GET: QUANGCAOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUANGCAO qUANGCAO = db.QUANGCAOs.Find(id);
            if (qUANGCAO == null)
            {
                return HttpNotFound();
            }
            return View(qUANGCAO);
        }

        // POST: QUANGCAOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUANGCAO qUANGCAO = db.QUANGCAOs.Find(id);
            db.QUANGCAOs.Remove(qUANGCAO);
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
