using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;


namespace ONLINETICARIOTOMASYON.Controllers
{
  [AllowAnonymous]
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
     
        public ActionResult Index(string p)
        {

            var urunler = from x in c.Urunlers select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));


            }

            return View(urunler.Where(x=>x.Durum==true).ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategorıs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategorıAd,
                                               Value = x.KategorıID.ToString()


                                           }).ToList();

            ViewBag.dgr1 = deger1;

          


            return View();

        }
        [HttpPost]
        public ActionResult YeniUrun(Urunler p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadı = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadı + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UrunGorsel = "/image/" + dosyaadı + uzantı;

            }
            c.Urunlers.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");



        }
        public ActionResult UrunSil(int id)
        {

            var deger = c.Urunlers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("index");

        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategorıs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategorıAd,
                                               Value = x.KategorıID.ToString()


                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urundeger = c.Urunlers.Find(id);
            return View("UrunGetir", urundeger);

        }

        [HttpPost]

        public ActionResult UrunGuncelle(Urunler p, HttpPostedFileBase urungorsel)

        {

            var urn = c.Urunlers.Find(p.UrunID);
            urn.AlısFıyat = p.AlısFıyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatısFıyat = p.SatısFıyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;



            if (ModelState.IsValid)

            {

                if (urungorsel != null)

                {

                    string dosyaadi = Path.GetFileName(urungorsel.FileName);



                    string yol = "/Image/" + dosyaadi;

                    urungorsel.SaveAs(Server.MapPath(yol));

                    urn.UrunGorsel = yol;

                }

            }



            c.SaveChanges();

            return RedirectToAction("Index");

        }
        //public ActionResult UrunGuncelle(Urunler p)
        //{

        //    var urn = c.Urunlers.Find(p.UrunID);
        //    urn.AlısFıyat = p.AlısFıyat;
        //    urn.Durum = p.Durum;
        //    urn.Kategoriid = p.Kategoriid;
        //    urn.Marka = p.Marka;
        //    urn.SatısFıyat = p.SatısFıyat;
        //    urn.Stok = p.Stok;
        //    urn.UrunAd = p.UrunAd;
        //    urn.UrunGorsel = p.UrunGorsel;





        //    c.SaveChanges();
        //    return RedirectToAction("index");

        //}
        public ActionResult UrunListesi()
        {
            var degerler = c.Urunlers.ToList();
            return View(degerler);

        }

        [HttpGet]

        public ActionResult SatısYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd + "" + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()

                                           }
                                        ).ToList();

            ViewBag.dgr1 = deger3;

            var deger1 = c.Urunlers.Find(id);
            ViewBag.dgr2 = deger1.UrunID;
            ViewBag.dgr4 = deger1.SatısFıyat;

            return View();

        }
        [HttpPost]
        public ActionResult SatısYap(SatısHareket s)
        {
            s.Tarıh = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatısHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("index","Satıs");



        }

    }
}