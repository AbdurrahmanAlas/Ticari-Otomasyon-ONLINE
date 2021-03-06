using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Departman
    {

        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }

        public bool Duru { get; set; }
        public ICollection<Personel> Personels { get; set; }

    }
}