using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Admın
    {

        [Key]
        public int AdmınID { get; set; }
        [Column(TypeName = "Varchar")]
       
        public string KullanıcıAd { get; set; }
        [Column(TypeName = "Varchar")]
        
        public string Sıfre { get; set; }
        [Column(TypeName = "Varchar")]
        
        public string Yetkı { get; set; }



    }
}