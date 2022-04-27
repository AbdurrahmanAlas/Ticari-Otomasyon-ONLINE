using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{
    public class SatısController : Controller
    {
        // GET: Satıs
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatısHarekets.ToList();


            return View(degerler);
        }
        [HttpGet]
        public ActionResult YenıSatıs()
        {
            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()

                                           }
                                        ).ToList();

            List<SelectListItem> deger2 = (from x in c.Carılers.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.CarıAd+""+x.CarıSoyad,
                                               Value = x.CarıID.ToString()

                                           }
                                       ).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd+""+x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()

                                           }
                                       ).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;



            return View();
        }
        [HttpPost]
        public ActionResult YenıSatıs(SatısHareket s)
        {
            
            s.Tarıh = DateTime.Parse( DateTime.Now.ToShortDateString());
            c.SatısHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("index");


        }

        public ActionResult SatısGetır(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()

                                           }
                                          ).ToList();

            List<SelectListItem> deger2 = (from x in c.Carılers.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.CarıAd + "" + x.CarıSoyad,
                                               Value = x.CarıID.ToString()

                                           }
                                       ).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd + "" + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()

                                           }
                                       ).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var deger = c.SatısHarekets.Find(id);
            return View("SatısGetır", deger);


        }



        public ActionResult SatısGuncelle(SatısHareket p)
        {

            var deger = c.SatısHarekets.Find(p.SatısID);
            deger.CarıID = p.CarıID;
            deger.Adet = p.Adet;
            deger.Fıyat = p.Fıyat;
            deger.PersonelID = p.PersonelID;
            deger.Tarıh = p.Tarıh;
            deger.ToplamTutar = p.ToplamTutar;
            deger.UrunID = p.UrunID;
            c.SaveChanges();
            return RedirectToAction("index");

        }

        public ActionResult SatısDetay(int id)
        {

            var degerler = c.SatısHarekets.Where(x => x.SatısID == id).ToList();
            return View(degerler);
        }

    }
}