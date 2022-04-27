using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class SatısHareket
    {

        [Key]
        public int SatısID { get; set; }
        //ÜRÜN CARİ  PERSONEL 
        public DateTime     Tarıh { get; set; }
        public int     Adet { get; set; }
        public decimal     Fıyat { get; set; }
        public decimal     ToplamTutar { get; set; }
        public int UrunID { get; set; }
        public int CarıID { get; set; }
        public int PersonelID { get; set; }

        public virtual Urunler Urunler { get; set; }
        public virtual Carıler Carıler { get; set; }
        public virtual Personel Personel { get; set; }

    }
}