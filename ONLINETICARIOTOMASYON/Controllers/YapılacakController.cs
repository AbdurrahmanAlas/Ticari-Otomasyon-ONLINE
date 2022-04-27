using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{
    public class YapılacakController : Controller
    {
        // GET: Yapılacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carılers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Urunlers.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Kategorıs.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = (from x in c.Carılers select x.CarıSehır).Distinct().Count().ToString();
            ViewBag.d4 = deger4;


            var yapılacaklar = c.Yapılacaks.ToList();

            return View(yapılacaklar);

            return View();
        }
    }
}