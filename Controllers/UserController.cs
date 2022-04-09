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
    public class UserController : Controller
    {
        private RentCarEntities1 db = new RentCarEntities1();

        // GET: User
        public ActionResult Index()
        {
            return View(db.userTable.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTable userTable = db.userTable.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUser,username,password,nameUser,familyUser,EGN,phone,email,role")] userTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.userTable.Add(userTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTable);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTable userTable = db.userTable.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUser,username,password,nameUser,familyUser,EGN,phone,email,role")] userTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTable);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userTable userTable = db.userTable.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userTable userTable = db.userTable.Find(id);
            db.userTable.Remove(userTable);
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
