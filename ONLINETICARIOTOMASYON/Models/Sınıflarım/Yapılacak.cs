using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Yapılacak
    {
        [Key]
        public int YapılacakID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Baslık { get; set; }

        [Column(TypeName = "bit")]
        public bool Durum { get; set; }

    }

}
