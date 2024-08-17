using coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace coffe.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_User user)
        {
            if (ModelState.IsValid)
            {
                coffeEntities context = new coffeEntities();
                context.tbl_User.Add(user);
                context.SaveChanges();
                var usridentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Password" ,user.Password)
                }, "AppCookie");
                Request.GetOwinContext().Authentication.SignIn(usridentity);
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_User user)
        {
            coffeEntities context = new coffeEntities();
            var loggeduser = context.tbl_User.FirstOrDefault(n => n.Email == user.Email && n.Password == user.Password);
            if (loggeduser != null)
            {
                var signin = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, loggeduser.Email),
                    new Claim("Password" ,loggeduser.Password)
                }, "AppCookie");
                Request.GetOwinContext().Authentication.SignIn(signin);
                return RedirectToAction("Index", "Main");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Index", "Main");
        }


    }

}