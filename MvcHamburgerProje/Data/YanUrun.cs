using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcHamburgerProje.Data
{
	public class YanUrun
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "{0} zorunludur")]
        public string Ad { get; set; } = null!;

        [Required(ErrorMessage = "{0} zorunludur")]
        [Precision(18, 2)]
		public decimal? Fiyat { get; set; }

		public List<Siparis> Siparisler { get; set; } = new();

		[NotMapped]
		public string Onizleme => $"{Ad} (+{Fiyat?.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-TR"))})";
    }
}
