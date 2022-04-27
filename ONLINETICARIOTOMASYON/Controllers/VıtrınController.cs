using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONLINETICARIOTOMASYON.Models.Sınıflarım;
namespace ONLINETICARIOTOMASYON.Controllers
{
    public class VıtrınController : Controller
    {
        // GET: Vıtrın
        Context c = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Urunlers.ToList();
            cs.Deger2 = c.Detays.ToList();
            return View(cs);

            
        }
        [HttpPost]
        public ActionResult Index(Iletısım t)
        {
            c.Iletısıms.Add(t);
            c.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}