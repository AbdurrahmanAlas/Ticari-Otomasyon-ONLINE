using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class FaturaKalem
    {[Key]
        public int FaturaKalemID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Acıklama { get; set; }
        public int     Mıktar { get; set; }
        public decimal     BırımFıyat { get; set; }
        public decimal     Tutar { get; set; }

        public int FaturaID { get; set; }
        public virtual Faturalar Faturalars { get; set; }
        
    }
}