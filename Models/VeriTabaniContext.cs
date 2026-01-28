using System.Data.Entity;

namespace InternetProg.Models
{
    public class VeriTabaniContext : DbContext
    {
       
        public VeriTabaniContext() : base("name=InternetProgBaglanti")
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<SliderResim> SliderResimleri { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<NufusBilgi> NufusBilgileri { get; set; }
        public DbSet<TuristikYer> TuristikYerler { get; set; }
    }
}