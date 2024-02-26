using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcHamburgerProje.Data;

namespace MvcHamburgerProje.Areas.Admin.Controllers
{
	[Area("Admin")]

	[Authorize(Roles ="Administrator")]
	public class DashboardController : Controller
	{
		private readonly UserManager<Kullanici> _userManager;
		private readonly ApplicationDbContext _db;

		public DashboardController(UserManager<Kullanici> userManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_db = db;
		}

		public async Task<IActionResult> Index(string id = "herkes" , DateTime? date=null)
		{
			//var siparisler = _db.Siparisler.Include(x=>x.Menu);
			var usersInRole = await _userManager.GetUsersInRoleAsync("Musteri");

			List<Siparis> siparisler;
			if (id == "herkes")
			{
				siparisler = _db.Siparisler.Include(x => x.Menu).ToList();

				//ViewBag.Siparisler = siparisler.ToList();
			}
			else
			{
				ViewBag.Id = id;
				//ViewBag.Siparisler = siparisler.Where(x=>x.KullaniciId == id).ToList();
				siparisler = _db.Siparisler.Include(x => x.Menu).Where(x => x.KullaniciId == id).ToList();

			}
			if (date != null)
			{
				siparisler=siparisler.Where(x => x.Tarih.ToShortDateString() == ((DateTime)date).ToShortDateString()).ToList();
				ViewBag.Tarih = date;
			}
			else
			{
				ViewBag.Tarih = DateTime.Today;
			}
			ViewBag.Siparisler= siparisler;

			return View(usersInRole);
		}
	}
}
