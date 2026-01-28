using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProg.Models
{
    [Table("SliderResimleri")]
    public class SliderResim
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Resim URL")]
        [Required(ErrorMessage = "Resim linki zorunludur.")]
        public string ResimUrl { get; set; }

        public int Sira { get; set; }
    }
}