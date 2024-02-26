using System.ComponentModel.DataAnnotations;

namespace MvcHamburgerProje.Data
{
    public class Adres
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        public string Ad { get; set; } = null!;

        [Display(Name ="Açıklama")]
        [Required(ErrorMessage = "{0} zorunludur")]
        public string Acıklama { get; set; } = null!;

        [Display(Name = "Sıra")]
        [Required(ErrorMessage = "{0} zorunludur")]
        public int Sira { get; set; } = 0;
    }
}
