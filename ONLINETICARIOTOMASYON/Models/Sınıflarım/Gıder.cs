using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Gıder
    {
        [Key]
        public int GıderID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string    Acıklama { get; set; }
        public DateTime    Tarıh { get; set; }
        public decimal    Tutar { get; set; }


    }
}