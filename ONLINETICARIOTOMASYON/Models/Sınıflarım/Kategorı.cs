using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Kategorı
    {
        [Key]
        public int KategorıID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategorıAd { get; set; }

        public ICollection<Urunler> Uruns { get; set; }

    }
}