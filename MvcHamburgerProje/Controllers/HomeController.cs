using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcHamburgerProje.Data;
using MvcHamburgerProje.Models;
using SQLitePCL;
using System.Diagnostics;

namespace MvcHamburgerProje.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly UserManager<Kullanici> userManager;
		private readonly UserManager<Kullanici> _userManager;
		private readonly ApplicationDbContext _db;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
		{
			_logger = logger;
			_db = db;
		}

		public IActionResult Index(int sayfa = 1, string liste = "hepsi")
		{
			ViewBag.Sayfa = sayfa;
			ViewBag.Liste = liste;

			IQueryable<Menu> urun;

			if (liste == "hepsi")
				urun = _db.Menuler;

			else if (liste == "populer")
			{
				//var siparisler = _db.Siparisler.GroupBy(x => x.MenuId).OrderByDescending(group => group.Sum(x => x.Adet)).Take(10);
				//ViewBag.Populer = siparisler.Select(x => x.Key);

				//var menuler= _db.Menuler.Include(x=>x.Siparisler).GroupBy(x=>x.Id).OrderByDescending(group => group.Sum(x => x.Siparisler.Count())).Take(10).ToList();


				var enCokSiparisEdilenler = _db.Siparisler
					.GroupBy(siparis => siparis.MenuId)
					.Select(grup => new { MenuId = grup.Key, ToplamSiparisSayisi = grup.Sum(siparis => siparis.Adet) })
					.OrderByDescending(grup => grup.ToplamSiparisSayisi)
					.Take(10)
					;

				var populerMenuler=enCokSiparisEdilenler.Select(x => x.MenuId);

				urun = _db.Menuler.Where(x=>populerMenuler.Contains(x.Id));
			}
			else
				urun = _db.Menuler.OrderByDescending(x => x.Id).Take(10);

			return View(urun);
		}


		public IActionResult About()
		{
			return View(_db.Adresler.OrderBy(x => x.Sira).ToList());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
