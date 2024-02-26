using MvcHamburgerProje.Data;
using System.Drawing.Printing;

namespace MvcHamburgerProje.Models
{
    public class SiparisGuncelleVM
    {

        public string Boyut { get; set; } = null!;

        public int Adet { get; set; }

		public string? Not { get; set; } = null!;

        public decimal Tutar { get; set; }

        public List<YanUrun> TumYanUrunler { get; set; } = new();
        public List<YanUrun> YanUrunler { get; set; } = new();

        public Menu MevcutMenu { get; set; } = null!;

	}
}
