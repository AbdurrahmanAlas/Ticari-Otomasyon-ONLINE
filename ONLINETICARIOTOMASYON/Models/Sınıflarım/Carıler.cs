using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Carıler
    {
        [Key]
        public int CarıID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz")]
        public string CarıAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]

        public string CarıSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]

        public string CarıSehır { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CarıMaıl { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CarıSıfre { get; set; }

        public bool Durum { get; set; }


        public ICollection<SatısHareket> SatısHarekets { get; set; }
    }
}