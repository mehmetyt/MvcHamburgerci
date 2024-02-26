using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcHamburgerProje.Data;

namespace MvcHamburgerProje.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Administrator")]

	public class YanUrunController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YanUrunController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/YanUrun
        public async Task<IActionResult> Index()
        {
            return View(await _context.YanUrunler.ToListAsync());
        }

        // GET: Admin/YanUrun/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanUrun = await _context.YanUrunler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yanUrun == null)
            {
                return NotFound();
            }

            return View(yanUrun);
        }

        // GET: Admin/YanUrun/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/YanUrun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Fiyat")] YanUrun yanUrun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yanUrun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yanUrun);
        }

        // GET: Admin/YanUrun/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanUrun = await _context.YanUrunler.FindAsync(id);
            if (yanUrun == null)
            {
                return NotFound();
            }
            return View(yanUrun);
        }

        // POST: Admin/YanUrun/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Fiyat")] YanUrun yanUrun)
        {
            if (id != yanUrun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yanUrun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YanUrunExists(yanUrun.Id))
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
            return View(yanUrun);
        }

        // GET: Admin/YanUrun/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanUrun = await _context.YanUrunler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yanUrun == null)
            {
                return NotFound();
            }

            return View(yanUrun);
        }

        // POST: Admin/YanUrun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yanUrun = await _context.YanUrunler.FindAsync(id);
            if (yanUrun != null)
            {
                _context.YanUrunler.Remove(yanUrun);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YanUrunExists(int id)
        {
            return _context.YanUrunler.Any(e => e.Id == id);
        }
    }
}
