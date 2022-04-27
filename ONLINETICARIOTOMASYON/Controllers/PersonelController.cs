using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;


namespace ONLINETICARIOTOMASYON.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();


            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()


                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();


        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if(Request.Files.Count>0)
            {
                string dosyaadı =Path.GetFileName(Request.Files[0].FileName);
                string uzantı=Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadı + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/image/" + dosyaadı + uzantı;

            }



            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");



           


        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();

            return View(sorgu);
        }

      
        public ActionResult PersonelGetır(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()


                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetır", prs);

           

        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadı = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadı + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/image/" + dosyaadı + uzantı;

            }
            var per = c.Personels.Find(p.PersonelID);
  
            per.PersonelAd = p.PersonelAd;
            per.PersonelSoyad = p.PersonelSoyad;
            per.PersonelGorsel = p.PersonelGorsel;
            per.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("index");


        }
    }
}