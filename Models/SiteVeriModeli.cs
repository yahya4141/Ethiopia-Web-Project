using System.Collections.Generic;

namespace InternetProg.Models
{
    public class SiteVeriModeli
    {
        public List<Sehir> SehirlerListesi { get; set; }
        public List<NufusBilgi> NufusListesi { get; set; }
        public List<TuristikYer> TuristikYerlerListesi { get; set; }
    }
}