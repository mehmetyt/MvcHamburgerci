using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcHamburgerProje.Data
{
	public class ApplicationDbContext : IdentityDbContext<Kullanici>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<YanUrun> YanUrunler { get; set; }
        public DbSet<Adres> Adresler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Menu>().HasData(
                new Menu() { Id=1,Ad="Big King",KucukFiyat=185, OrtaFiyat = 190, BuyukFiyat = 195, Resim ="1.jpg", Aciklama="big king aciklama"},
                new Menu() { Id=2,Ad="Double Chicken", KucukFiyat = 180, OrtaFiyat = 185, BuyukFiyat = 190, Resim = "2.jpg", Aciklama="double chicken aciklama"}
                );
            builder.Entity<YanUrun>().HasData(
                new YanUrun() { Id=1,Ad="Mayonez",Fiyat=185},
                new YanUrun() { Id=2,Ad="Ketçap",Fiyat=190}
                );
        }
    }
}
