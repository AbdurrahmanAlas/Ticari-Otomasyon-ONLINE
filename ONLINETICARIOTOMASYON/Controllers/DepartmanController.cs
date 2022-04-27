using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{
    //[Authorize]
    //[Authorize(Roles = "A")]

    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
       
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Duru == false).ToList();


            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult DepartmanEkle()
        {


            return View();
        }



        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {

            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("index");

        }


        public ActionResult DepartmanSil(int id)
        {



            var dep = c.Departmans.Find(id);
            dep.Duru = true;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmans.Find(id);
            return View("DepartmanGetir", dpt);




        }


        public ActionResult DepartmanGuncelle(Departman p)
        {


            var dept = c.Departmans.Find(p.DepartmanID);
            dept.DepartmanAd = p.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var dpt = c.Departmans.Where(x => x.DepartmanID == id).Select(y =>
                  y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;

            var degerler = c.Personels.Where(x => x.DepartmanID == id).ToList();

            return View(degerler);

        }
        public ActionResult DepartmanPersonelSatıs(int id)
        {

            var degerler = c.SatısHarekets.Where(x => x.PersonelID == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + "" + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);

        }
    }
}