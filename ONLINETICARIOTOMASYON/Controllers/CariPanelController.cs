using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;

namespace ONLINETICARIOTOMASYON.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel


        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CarıMaıl"];

            var degerler = c.Carılers.FirstOrDefault(x => x.CarıMaıl == mail);


            ViewBag.m = mail;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparişlerim()
        {

            var mail = (string)Session["CarıMaıl"];
            var id = c.Carılers.Where(x => x.CarıMaıl == mail.ToString()).Select(y => y.CarıID).FirstOrDefault();

            var degerler = c.SatısHarekets.Where(x => x.CarıID == id).ToList();
            return View(degerler);


        }
        [Authorize]
        public ActionResult KargoTakip( string p)
        {
            var k = from x in c.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());
        
        }

        public ActionResult CariKargoTakip(string id)
        {

            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();

            return View(degerler);

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }

    }
}