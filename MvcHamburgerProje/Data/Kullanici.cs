using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcHamburgerProje.Data
{
	public class Kullanici:IdentityUser
	{

		[Required(ErrorMessage ="{0} zorunludur.")]
		public string Ad { get; set; } = null!;

        [Required(ErrorMessage = "{0} zorunludur.")]
        public string Soyad { get; set; } = null!;

        [Required(ErrorMessage = "{0} zorunludur.")]
        public string Adres { get; set; } = null!;
        public List<Siparis> Siparisler { get; set; } = new();

		[NotMapped]
		public string Onizleme => $"{Ad} {Soyad} ({Id})";

	}
}
