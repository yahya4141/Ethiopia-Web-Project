using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProg.Models
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad zorunludur.")]
        public string Ad { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string Soyad { get; set; }

        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "E-Posta zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Sifre { get; set; }

        public string Rol { get; set; } // Admin veya Uye
    }
}