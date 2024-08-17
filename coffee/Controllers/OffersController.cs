using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coffee.Models;

namespace coffee.Controllers
{
    public class OffersController : Controller
    {
        private coffeEntities db = new coffeEntities();

        // GET: Offers
        public ActionResult Index()
        {
            return View(db.tbl_Offer.ToList());
        }

        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Offer tbl_Offer = db.tbl_Offer.Find(id);
            if (tbl_Offer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Offer);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Img")] tbl_Offer tbl_Offer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Offer.Add(tbl_Offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Offer);
        }

        // GET: Offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Offer tbl_Offer = db.tbl_Offer.Find(id);
            if (tbl_Offer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Img")] tbl_Offer tbl_Offer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Offer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Offer);
        }

        // GET: Offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Offer tbl_Offer = db.tbl_Offer.Find(id);
            if (tbl_Offer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Offer tbl_Offer = db.tbl_Offer.Find(id);
            db.tbl_Offer.Remove(tbl_Offer);
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
