using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {

            var deger1 = c.Carılers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Urunlers.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategorıs.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Urunlers.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Urunlers select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = (from x in c.Urunlers orderby x.SatısFıyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Urunlers orderby x.SatısFıyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = c.Urunlers.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d9 = deger9;
            var deger10 = c.Urunlers.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.SatısHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d11 = deger11;
            DateTime bugun = DateTime.Today;
            var deger12 = c.SatısHarekets.Count(x => x.Tarıh == bugun).ToString();
            ViewBag.d12 = deger12;

            return View();
        }
    }
}