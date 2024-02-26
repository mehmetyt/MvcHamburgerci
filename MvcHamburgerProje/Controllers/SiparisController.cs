using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcHamburgerProje.Areas.Admin.Models;
using MvcHamburgerProje.Data;
using MvcHamburgerProje.Models;
using System.Text;

namespace MvcHamburgerProje.Controllers
{
	[Authorize(Roles ="Musteri")]
	public class SiparisController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<Kullanici> _userManager;

		public SiparisController(ApplicationDbContext db, UserManager<Kullanici> userManager)
		{
			_db = db;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index(int id)
		{
			Menu menu = await _db.Menuler.FindAsync(id)!;
			if (menu == null)
			{
				return NotFound();
			}

			List<YanUrun> yanUrunler = await _db.YanUrunler.ToListAsync();


			ViewBag.YanUrunler = yanUrunler;
			ViewBag.Menu = menu;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(SiparisVM vm, List<int> yanUrun)
		{

			if (ModelState.IsValid)
			{
				Siparis siparis = new Siparis()
				{
					KullaniciId = _userManager.GetUserId(User),
					Tarih = DateTime.Now,
					Adet = vm.Adet,
					Not = vm.Not,
					Boyut = vm.Boyut,
					MenuId= vm.MenuId,
					Tutar= vm.Tutar,
					SiparisNumarasi=GenerateOrderNumber()
				};
				var menu = await _db.Menuler.FindAsync(vm.MenuId);
				foreach (int item in yanUrun)
				{
					siparis.YanUrunler.Add(await _db.YanUrunler.FindAsync(item)!);
				}
				decimal sonTutar = 0;
				if(siparis.Boyut == "Buyuk")
				{
					sonTutar = menu.BuyukFiyat;
                   
                }
				else if(siparis.Boyut== "Orta")
				{
					sonTutar = menu.OrtaFiyat;
				}
				else
				{
					sonTutar =menu.KucukFiyat;
				}
				foreach (var item in siparis.YanUrunler)
				{
					sonTutar+= (decimal)item.Fiyat!;
				}
				sonTutar = sonTutar * siparis.Adet;
				siparis.Tutar = sonTutar;



				_db.Add(siparis);
				await _db.SaveChangesAsync();
				return RedirectToAction("Index", "Home", new {Islem = "basarili"});

			}
			return View(vm.MenuId);
		}
		public IActionResult Listele()
		{
			var musterininSiparisleri = _db.Siparisler.OrderByDescending(x=>x.Id).Include(x=> x.Menu).Where(x => x.KullaniciId == _userManager.GetUserId(User));
			return View(musterininSiparisleri);
		}
		public async Task<IActionResult> Ayrinti(int id)
		{
			var siparis = await _db.Siparisler.Include(x=>x.Menu).Include(x=> x.YanUrunler).FirstOrDefaultAsync(x=> x.Id == id);

			return View(siparis);
		}

		public IActionResult Sil(int id)
		{
			var siparis =  _db.Siparisler.Include(x => x.Menu).Include(x => x.YanUrunler).FirstOrDefault(x => x.Id == id);

			return View(siparis);
		}
		[HttpPost,ValidateAntiForgeryToken]
		public IActionResult Sil(Siparis siparis)
		{
			var silinecekSiparis = _db.Siparisler.Include(x => x.Menu).Include(x => x.YanUrunler).FirstOrDefault(x => x.Id == siparis.Id);
			_db.Siparisler.Remove(silinecekSiparis);
			_db.SaveChanges();
			return RedirectToAction("Listele", new {Islem = "silindi"});
		}




		static string GenerateOrderNumber()
		{
			Random random = new Random();
			const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			const int length = 10;
			StringBuilder builder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				char character = characters[random.Next(characters.Length)];
				builder.Append(character);
			}
			return builder.ToString();
		}

	}
}
