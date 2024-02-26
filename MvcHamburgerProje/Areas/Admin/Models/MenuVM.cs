using Microsoft.EntityFrameworkCore;
using MvcHamburgerProje.Attributes;
using MvcHamburgerProje.Data;
using System.ComponentModel.DataAnnotations;

namespace MvcHamburgerProje.Areas.Admin.Models
{
    public class MenuVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        public string Ad { get; set; } = null!;


        [Display(Name ="Küçük Boy Fiyatı" )]
        [Required(ErrorMessage = "{0} zorunludur")]
        [Precision(18, 2)]
        public decimal? KucukFiyat { get; set; }

        [Display(Name = "Orta Boy Fiyatı")]
        [Required(ErrorMessage = "{0} zorunludur")]
        [Precision(18, 2)]
        public decimal? OrtaFiyat { get; set; }

        [Display(Name = "Büyük Boy Fiyatı")]
        [Required(ErrorMessage = "{0} zorunludur")]
        [Precision(18, 2)]
        public decimal? BuyukFiyat { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "{0} zorunludur")]
        public string Aciklama { get; set; } = null!;

        [Resim]
        public IFormFile? Resim { get; set; }

    }
}
