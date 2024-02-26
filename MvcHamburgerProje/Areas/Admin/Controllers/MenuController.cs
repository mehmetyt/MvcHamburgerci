using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcHamburgerProje.Areas.Admin.Models;
using MvcHamburgerProje.Data;

namespace MvcHamburgerProje.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Administrator")]

	public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MenuController(ApplicationDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Menu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menuler.ToListAsync());
        }

        // GET: Admin/Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menuler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuVM vm)
        {
            if (ModelState.IsValid)
            {
                Menu menu = new Menu()
                {
                    Ad = vm.Ad,
                    BuyukFiyat = (decimal)vm.BuyukFiyat!,
                    KucukFiyat = (decimal)vm.KucukFiyat!,
                    OrtaFiyat = (decimal)vm.OrtaFiyat!,
                    Aciklama = vm.Aciklama
                };
                if (vm.Resim != null)
                {
                    string ext = Path.GetExtension(vm.Resim.FileName);
                    string yeniAd = Guid.NewGuid().ToString() + ext;
                    string dosyaYolu = Path.Combine(_env.WebRootPath, "img", yeniAd);

                    using (var fs = new FileStream(dosyaYolu, FileMode.CreateNew))
                    {
                        vm.Resim.CopyTo(fs);
                    };
                    menu.Resim = yeniAd;
                }
                else
                {
                    menu.Resim = "default.jpg";
                }


                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menuler.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }


            MenuVM vm = new MenuVM()
            {
                Id= menu.Id,
                Ad = menu.Ad,
                BuyukFiyat = menu.BuyukFiyat,
                KucukFiyat = menu.KucukFiyat,
                OrtaFiyat = menu.OrtaFiyat,
                Aciklama = menu.Aciklama

            };
            if (menu == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MenuVM vm)
        {
            ModelState.Remove("Resim");
            if (ModelState.IsValid)
            {
                Menu menu = _context.Menuler.Find(vm.Id)!;
                menu.Ad = vm.Ad;
                menu.BuyukFiyat = (decimal)vm.BuyukFiyat;
                menu.KucukFiyat = (decimal)vm.KucukFiyat;
                menu.OrtaFiyat = (decimal)vm.OrtaFiyat;
                menu.Aciklama =  vm.Aciklama;
                
                if (menu == null)
                {
                    return NotFound();
                }
                if (vm.Resim != null)
                {
                    string ext = Path.GetExtension(vm.Resim.FileName);
                    string yeniAd = Guid.NewGuid().ToString() + ext;
                    string dosyaYolu = Path.Combine(_env.WebRootPath, "img", yeniAd);

                    using (var fs = new FileStream(dosyaYolu, FileMode.CreateNew))
                    {
                        vm.Resim.CopyTo(fs);
                    };
                    if (menu.Resim != "default.jpg")
                    {
                        System.IO.File.Delete(Path.Combine(_env.WebRootPath, "img", menu.Resim!));
                    }
                    menu.Resim = yeniAd;

                }
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Admin/Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menuler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Admin/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menuler.FindAsync(id);
            if (menu != null)
            {
                _context.Menuler.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menuler.Any(e => e.Id == id);
        }
    }
}
