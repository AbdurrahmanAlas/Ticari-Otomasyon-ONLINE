using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {

            return PartialView();

        }
        [HttpPost]
        public PartialViewResult Partial1(Carıler p)
        {
            c.Carılers.Add(p);
            c.SaveChanges();
            return PartialView();





        }
        [HttpGet]
        public ActionResult CarıLogin1()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CarıLogin1(Carıler ca)
        {
            var bilgiler = c.Carılers.FirstOrDefault(x => x.CarıMaıl == ca.CarıMaıl && x.CarıSıfre == ca.CarıSıfre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CarıMaıl, false);
                Session["CarıMaıl"] = bilgiler.CarıMaıl.ToString();
                return RedirectToAction("Index", "CariPanel");


            }
            else {
                return RedirectToAction("Index", "Login");



            }





        }
        [HttpGet]
        public ActionResult AdminLogin()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admın p)
        {
            var bilgiler = c.Admıns.FirstOrDefault
               ( x => x.KullanıcıAd == p.KullanıcıAd && x.Sıfre == p.Sıfre);
            if (bilgiler != null)
            {

                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAd, false);
                Session["KullanıcıAd"] = bilgiler.KullanıcıAd.ToString();
                return RedirectToAction("Index", "Kategorı");


            } else
            {
                return RedirectToAction("Index", "Urun");


            


                
                


        }

        }
    } }