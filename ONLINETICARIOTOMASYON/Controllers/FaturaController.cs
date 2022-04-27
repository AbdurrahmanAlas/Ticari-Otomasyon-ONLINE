using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();

        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();

            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetır(int id)
        {

            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetır", fatura);

        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {

            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSerıNo = f.FaturaSerıNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.Saat = f.Saat;
            fatura.Tarıh = f.Tarıh;
            fatura.TeslımAlan = f.TeslımAlan;
            fatura.TeslımEden = f.TeslımEden;
            fatura.VergıDaıresı = f.VergıDaıresı;

            c.SaveChanges();
            return RedirectToAction("index");

        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();
           
     
            return View(degerler);

        }
        [HttpGet]
        public ActionResult YenıKalem()
        {


            return View();

        }

        [HttpPost]
        public ActionResult   YenıKalem (FaturaKalem p)
        {
           c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");



        

        }

        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);

        }
        public ActionResult FaturaKaydet(string FaturaSerıNo,string FaturaSıraNo,DateTime Tarıh,string VergıDaıresı,
            string Saat,string TeslımEden,string TeslımAlan,string Toplam,FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSerıNo = FaturaSerıNo;
            f.FaturaSıraNo = FaturaSıraNo;
            f.Tarıh = Tarıh;
            f.VergıDaıresı = VergıDaıresı;
            f.Saat = Saat;
            f.TeslımAlan = TeslımAlan;
            f.TeslımEden = TeslımEden;
            f.Toplam = decimal.Parse(Toplam);
            c.Faturalars.Add(f);

            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.FaturaID = x.FaturaKalemID;
                fk.Acıklama = x.Acıklama;
                fk.BırımFıyat = x.BırımFıyat;
              
                fk.Mıktar = x.Mıktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
            }



            c.SaveChanges();
            return Json("Islem Başarılı", JsonRequestBehavior.AllowGet);


        }
            
       
    }
}