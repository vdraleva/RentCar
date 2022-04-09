using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class CarController : Controller
    {
        private RentCarEntities1 db = new RentCarEntities1();

        // GET: Car
        public ActionResult Index()
        {
            return View(db.carInfoTable.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carInfoTable carInfoTable = db.carInfoTable.Find(id);
            if (carInfoTable == null)
            {
                return HttpNotFound();
            }
            return View(carInfoTable);
        }
        public ActionResult GetCarModelByBrand(carInfoTable carBrand)
        {
            SpGetModelCarByBrand_Result(carBrand);
            
            return View(db.carInfoTable.ToList());
        }

        private void SpGetModelCarByBrand_Result(carInfoTable carBrand)
        {
            throw new NotImplementedException();
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCar,brandCar,modelCar,yearCar,numberSeats,priceCar,avaliable")] carInfoTable carInfoTable)
        {
            if (ModelState.IsValid)
            {
                db.carInfoTable.Add(carInfoTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carInfoTable);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carInfoTable carInfoTable = db.carInfoTable.Find(id);
            if (carInfoTable == null)
            {
                return HttpNotFound();
            }
            return View(carInfoTable);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCar,brandCar,modelCar,yearCar,numberSeats,priceCar,avaliable")] carInfoTable carInfoTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carInfoTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carInfoTable);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carInfoTable carInfoTable = db.carInfoTable.Find(id);
            if (carInfoTable == null)
            {
                return HttpNotFound();
            }
            return View(carInfoTable);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carInfoTable carInfoTable = db.carInfoTable.Find(id);
            db.carInfoTable.Remove(carInfoTable);
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
