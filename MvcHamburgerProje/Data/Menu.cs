using Microsoft.EntityFrameworkCore;

namespace MvcHamburgerProje.Data
{
	public class Menu
	{
		public int Id { get; set; }
		public string Ad { get; set; } = null!;

		[Precision(18,2)]
		public decimal KucukFiyat { get; set; }
		public decimal OrtaFiyat { get; set; }
		public decimal BuyukFiyat { get; set; }
		public string? Resim { get; set; }
		public string Aciklama { get; set; } = null!;

		public List<Siparis> Siparisler { get; set; } = new();

	}
}
