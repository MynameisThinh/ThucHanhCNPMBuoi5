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
    public class THAMDOesController : Controller
    {
        private QLBANSACHEntities db = new QLBANSACHEntities();

        // GET: THAMDOes
        public ActionResult Index()
        {
            return View(db.THAMDOes.ToList());
        }

        // GET: THAMDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMDO tHAMDO = db.THAMDOes.Find(id);
            if (tHAMDO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMDO);
        }

        // GET: THAMDOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: THAMDOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCH,Ngaydang,Noidungthamdo,Tongsobinhchon")] THAMDO tHAMDO)
        {
            if (ModelState.IsValid)
            {
                db.THAMDOes.Add(tHAMDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHAMDO);
        }

        // GET: THAMDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMDO tHAMDO = db.THAMDOes.Find(id);
            if (tHAMDO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMDO);
        }

        // POST: THAMDOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCH,Ngaydang,Noidungthamdo,Tongsobinhchon")] THAMDO tHAMDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHAMDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHAMDO);
        }

        // GET: THAMDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMDO tHAMDO = db.THAMDOes.Find(id);
            if (tHAMDO == null)
            {
                return HttpNotFound();
            }
            return View(tHAMDO);
        }

        // POST: THAMDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THAMDO tHAMDO = db.THAMDOes.Find(id);
            db.THAMDOes.Remove(tHAMDO);
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
