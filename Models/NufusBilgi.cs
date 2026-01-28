using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProg.Models
{
    [Table("NufusBilgileri")]
    public class NufusBilgi
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Yıl")]
        public int Yil { get; set; }

        [Display(Name = "Nüfus")]
        public string NufusSayisi { get; set; }
    }
}