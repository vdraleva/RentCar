using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class HomeController : Controller
    {
        RentCarEntities1 db = new RentCarEntities1();
        // GET: Home
        [Authorize(Roles = "Admin")]
        [AllowAnonymous]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index(userTable userTable)
        {
            return View(db.userTable);
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(userTable user)
        {
            if (db.userTable.Any(x => x.username == user.username))
            {
                ViewBag.Notification = "Вече съществува такъв акаунт";
                return View();
            }
            if (ModelState.IsValid)
            {
                using (RentCarEntities1 db = new RentCarEntities1())
                {
                    db.userTable.Add(user);
                    db.SaveChanges();
                    ModelState.Clear();
                ViewBag.Message = user.nameUser + " " + user.familyUser + " успешно се регистрира!";
                }
                
            }
            return View();
        }
        [Authorize]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(userTable userTable, string returnUrl)
        {
            RentCarEntities1 db = new RentCarEntities1();
            var checkLogin = db.userTable.Where(x => x.username == userTable.username && x.password == userTable.password).FirstOrDefault();
            if (checkLogin != null)
            {
                FormsAuthentication.SetAuthCookie(checkLogin.username, false);                
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Грешно потребителско име или парола!");
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}