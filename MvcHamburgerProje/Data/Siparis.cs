using System.ComponentModel.DataAnnotations.Schema;

namespace MvcHamburgerProje.Data
{
	public class Siparis
	{
        public int Id { get; set; }

        public string KullaniciId { get; set; } = null!;
		public Kullanici Kullanici { get; set; }= null!;

        public int MenuId { get; set; }

        public Menu Menu { get; set; } = null!;
		public List<YanUrun> YanUrunler  { get; set; } = new();

        public string Boyut { get; set; } = null!;

        public int Adet { get; set; }

        public DateTime Tarih {  get; set; }

        public string? Not { get; set; }
        public string SiparisNumarasi { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
		public decimal Tutar { get; set; }
	}
}
