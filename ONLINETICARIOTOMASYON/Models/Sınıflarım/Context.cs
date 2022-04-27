using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ONLINETICARIOTOMASYON.Models.Sınıflarım
{
    public class Context:DbContext
    {
        public DbSet<Admın> Admıns { get; set; }
        public DbSet<Carıler> Carılers { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gıder> Gıders { get; set; }
        public DbSet<Kategorı> Kategorıs { get; set; }
        public DbSet<Personel  > Personels { get; set; }
        public DbSet<SatısHareket> SatısHarekets { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }

        public DbSet<Detay>  Detays { get; set; }
        //public DbSet<Class1> Class1s { get; set; }
        public DbSet<Yapılacak> Yapılacaks { get; set; }
        public DbSet<Iletısım> Iletısıms { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
    }
}