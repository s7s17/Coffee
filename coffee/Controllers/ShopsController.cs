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
    public class ShopsController : Controller
    {
        private coffeEntities db = new coffeEntities();

        // GET: Shops
        public ActionResult Index()
        {
            return View(db.tbl_Shop.ToList());
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Shop tbl_Shop = db.tbl_Shop.Find(id);
            if (tbl_Shop == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Shop);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,img,Price")] tbl_Shop tbl_Shop)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Shop.Add(tbl_Shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Shop);
        }

        // GET: Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Shop tbl_Shop = db.tbl_Shop.Find(id);
            if (tbl_Shop == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,img,Price")] tbl_Shop tbl_Shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Shop);
        }

        // GET: Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Shop tbl_Shop = db.tbl_Shop.Find(id);
            if (tbl_Shop == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Shop tbl_Shop = db.tbl_Shop.Find(id);
            db.tbl_Shop.Remove(tbl_Shop);
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
