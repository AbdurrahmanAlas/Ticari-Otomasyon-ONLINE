using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]

        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlısFıyat { get; set; }
        public decimal SatısFıyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int Kategoriid { get; set; }
        public virtual Kategorı Kategorı { get; set; }
        //true ve falsse için bool
        public ICollection<SatısHareket> SatısHarekets { get; set; }


    }
}