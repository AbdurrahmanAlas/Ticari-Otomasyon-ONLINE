using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{

    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
     
        public ActionResult Index()
        {
            Class1 cs = new Class1();

            cs.Deger1 = c.Urunlers.Where(x => x.UrunID == 11).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayID == 5).ToList();

           // var degerler = c.Urunlers.Where(x => x.UrunID == 1).ToList();


            return View(cs);
        }
    }
}