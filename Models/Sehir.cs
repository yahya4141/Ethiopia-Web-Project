using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProg.Models
{
    [Table("Sehirler")]
    public class Sehir
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Şehir Adı")]
        [Required(ErrorMessage = "Şehir adı zorunludur.")]

       
        [RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ\s]*$", ErrorMessage = "Şehir isminde rakam veya sembol kullanamazsın, sadece harf girmelisin.")]
        public string SehirAdi { get; set; }

        [Display(Name = "Nüfus")]
        public string Nufus { get; set; }

        [Display(Name = "Öne Çıkan Özellik")]
        public string OneCikan { get; set; }

        [Display(Name = "Şehir Resmi")]
        public string ResimUrl { get; set; }

        [Display(Name = "Bilgi")]
        [Required(ErrorMessage = "Bilgi alanı zorunludur.")]
        public string Bilgi { get; set; }
    }
}