using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhytRxProject.Models;

namespace PhytRxProject.Controllers
{
    public class Rx2Controller : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Rx2
        public ActionResult Index(int pID)
        {
            var rx2 = db.Rx2.Include(r => r.Patient);
            ViewBag.PID = pID;
            return View(rx2.ToList());
        }
        
        public ActionResult ViewPatient()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyAction(string search)
        {

            //do whatever you need with the parameter, 
            //like using it as parameter in Linq to Entities or Linq to Sql, etc. 
            //Suppose your search result will be put in variable "result".
            ViewData.Model = db.Rx2;
            return View();

            


        }
        // GET: Rx2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rx2 rx2 = db.Rx2.Find(id);
            if (rx2 == null)
            {
                return HttpNotFound();
            }
            return View(rx2);
        }

        // GET: Rx2/Create
        public ActionResult Create(int pID)
        {
            ViewBag.PID = pID;
            //ViewBag.PID = new SelectList(db.Patients, "PID", "UserID");
            return View();
        }

        // POST: Rx2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RXID,RxName,ExID,PID,PhID,LogID,UsersName")] Rx2 rx2)
        {
            if (ModelState.IsValid)
            {
                db.Rx2.Add(rx2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PID = new SelectList(db.Patients, "PID", "UserID", rx2.PID);
            return View(rx2);
        }

        // GET: Rx2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rx2 rx2 = db.Rx2.Find(id);
            if (rx2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "UserID", rx2.PID);
            return View(rx2);
        }

        // POST: Rx2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RXID,RxName,ExID,PID,PhID,LogID,UsersName")] Rx2 rx2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rx2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "UserID", rx2.PID);
            return View(rx2);
        }

        // GET: Rx2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rx2 rx2 = db.Rx2.Find(id);
            if (rx2 == null)
            {
                return HttpNotFound();
            }
            return View(rx2);
        }

        // POST: Rx2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rx2 rx2 = db.Rx2.Find(id);
            db.Rx2.Remove(rx2);
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
