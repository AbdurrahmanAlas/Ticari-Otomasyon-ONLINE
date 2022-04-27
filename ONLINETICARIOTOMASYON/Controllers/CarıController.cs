using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{
    
    public class CarıController : Controller
    {
        // GET: Carı
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carılers.Where(x=>x.Durum==true).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCarı()
        {

            return View();


        }
        public ActionResult YeniCarı(Carıler p)
        {
            p.Durum = true;
            c.Carılers.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");



        }
        public ActionResult CarıSil(int id)
        {

            var cr = c.Departmans.Find(id);
            cr.Duru = false;
            c.SaveChanges();
            return RedirectToAction("index");


        }

        public ActionResult CarıGetır(int id)

        {

            var carı = c.Carılers.Find(id);
            return View("CarıGetır", carı);


        }

        public ActionResult CarıGuncelle(Carıler p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");

            }
            var carı = c.Carılers.Find(p.CarıID);
            carı.CarıAd = p.CarıAd;
            carı.CarıSoyad = p.CarıSoyad;
            carı.CarıSehır = p.CarıSehır;
            carı.CarıMaıl = p.CarıMaıl;
            c.SaveChanges();
            return RedirectToAction("index");


        }

        public ActionResult MusterıSatıs(int id)
        {
            var degerler = c.SatısHarekets.Where(x => x.CarıID == id).ToList();
            var cr = c.Carılers.Where(x => x.CarıID == id).Select(y => y.CarıAd + "" + y.CarıSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);

        }

    }
}