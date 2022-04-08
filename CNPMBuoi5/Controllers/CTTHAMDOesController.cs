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
    public class CTTHAMDOesController : Controller
    {
        private QLBANSACHEntities db = new QLBANSACHEntities();

        // GET: CTTHAMDOes
        public ActionResult Index()
        {
            var cTTHAMDOes = db.CTTHAMDOes.Include(c => c.THAMDO);
            return View(cTTHAMDOes.ToList());
        }

        // GET: CTTHAMDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTTHAMDO cTTHAMDO = db.CTTHAMDOes.Find(id);
            if (cTTHAMDO == null)
            {
                return HttpNotFound();
            }
            return View(cTTHAMDO);
        }

        // GET: CTTHAMDOes/Create
        public ActionResult Create()
        {
            ViewBag.MaCH = new SelectList(db.THAMDOes, "MaCH", "Noidungthamdo");
            return View();
        }

        // POST: CTTHAMDOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCH,STT,Noidungtraloi,Solanbinhchon")] CTTHAMDO cTTHAMDO)
        {
            if (ModelState.IsValid)
            {
                db.CTTHAMDOes.Add(cTTHAMDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCH = new SelectList(db.THAMDOes, "MaCH", "Noidungthamdo", cTTHAMDO.MaCH);
            return View(cTTHAMDO);
        }

        // GET: CTTHAMDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTTHAMDO cTTHAMDO = db.CTTHAMDOes.Find(id);
            if (cTTHAMDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCH = new SelectList(db.THAMDOes, "MaCH", "Noidungthamdo", cTTHAMDO.MaCH);
            return View(cTTHAMDO);
        }

        // POST: CTTHAMDOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCH,STT,Noidungtraloi,Solanbinhchon")] CTTHAMDO cTTHAMDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTTHAMDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCH = new SelectList(db.THAMDOes, "MaCH", "Noidungthamdo", cTTHAMDO.MaCH);
            return View(cTTHAMDO);
        }

        // GET: CTTHAMDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTTHAMDO cTTHAMDO = db.CTTHAMDOes.Find(id);
            if (cTTHAMDO == null)
            {
                return HttpNotFound();
            }
            return View(cTTHAMDO);
        }

        // POST: CTTHAMDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTTHAMDO cTTHAMDO = db.CTTHAMDOes.Find(id);
            db.CTTHAMDOes.Remove(cTTHAMDO);
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
