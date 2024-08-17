using coffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coffe.Controllers
{
    [AllowAnonymous]

    public class MainController : Controller
    {
        private coffeEntities context = new coffeEntities();
        // GET: Main
        public ActionResult Index()
        {
            //List<Offer> offerList = context.Offers.ToList();
            return View(context);
        }
        public ActionResult shop()
        {
            List<tbl_Shop> shops = context.tbl_Shop.ToList();
            return View(shops);
        }
        [Authorize]
        public ActionResult about()
        {

            return View();
        }
        public ActionResult blog()
        {

            return View();
        }
        public ActionResult coffees()
        {

            return View();
        }
        public ActionResult contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Register");
        }
        public ActionResult read_more(int id)
        {
            tbl_Offer offer = context.tbl_Offer.Find(id);
            return View(offer);
        }


    }
}