using RentCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCar.Controllers
{
    public class RentController : Controller
    {
        RentCarEntities1 db = new RentCarEntities1();
        // GET: Rent
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save()
        {
            return View();
        }
        [HttpGet]
        //this is to load the cars in the dropdown menu 
        public ActionResult Getcar()
        {
            var car = db.carInfoTable.ToList();
            //this transfer the compiler to Index from Rent folder
            return Json(car, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetModelsByMake(string model)
        {
            Models.RentCarEntities1 db = new Models.RentCarEntities1();
            List<Models.RentCarTable> models = db.RentCarTable.Where(p => p.Brand == model).ToList();

            return Json(models);
        }
    }
}