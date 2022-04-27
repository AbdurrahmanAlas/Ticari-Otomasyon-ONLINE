using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Faturalar
    {
      [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string FaturaSerıNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarıh { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergıDaıresı { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string Saat { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslımEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslımAlan { get; set; }

        public decimal Toplam { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }



    }
}