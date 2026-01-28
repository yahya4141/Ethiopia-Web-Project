using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProg.Models
{
    [Table("TuristikYerler")]
    public class TuristikYer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Yer Adı")]
        [Required(ErrorMessage = "Yer adı zorunludur.")]
        public string YerAdi { get; set; } 

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Resim URL")]
        public string ResimUrl { get; set; }
    }
}