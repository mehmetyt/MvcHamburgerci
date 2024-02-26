using MvcHamburgerProje.Data;
using System.ComponentModel.DataAnnotations;

namespace MvcHamburgerProje.Models
{
    public class SiparisVM
    {
        public int MenuId { get; set; }

        public string Boyut { get; set; } = null!;

        public int Adet { get; set; }

		public string? Not { get; set; } = null!;

        public decimal Tutar { get; set; }
    }
}
