using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
using PagedList;
using PagedList.Mvc;
namespace ONLINETICARIOTOMASYON.Controllers
{
    public class KategorıController : Controller
    {
        // GET: Kategorı
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategorıs.ToList().ToPagedList(sayfa,8);

            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();

        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategorı k)
        {
            c.Kategorıs.Add(k);
            c.SaveChanges();
            return RedirectToAction("index");

        }
        public ActionResult KategoriSil(int id)
        {

            var ktg = c.Kategorıs.Find(id);
            c.Kategorıs.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategorıs.Find(id);
            return View("KategoriGetir", kategori);



        }

        public ActionResult KategoriGuncelle(Kategorı k)

        {

            var ktgr = c.Kategorıs.Find(k.KategorıID);
            ktgr.KategorıAd = k.KategorıAd;
            c.SaveChanges();
            return RedirectToAction("index");

        }

        public ActionResult Deneme()
        {


            Class3 cs = new Class3();

            cs.Kategoriler = new SelectList(c.Kategorıs, "KategorıID", "KategorıAd");
            cs.Urunler = new SelectList(c.Urunlers, "UrunID", "UrunAd");
            return View(cs);


        }
        public JsonResult UrunGetir(int p)
        {

            var urunlistesi = (from x in c.Urunlers
                               join y in c.Kategorıs
                               on x.Kategorı.KategorıID equals y.KategorıID
                               where x.Kategorı.KategorıID == p
                               select new
                               {

                                   Text = x.UrunAd,
                                   Value = x.UrunID.ToString()

                               }

                             ).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet);

        }
    }
}