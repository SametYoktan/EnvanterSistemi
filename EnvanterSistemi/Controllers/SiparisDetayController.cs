using EnvanterSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvanterSistemi.Controllers
{
    public class SiparisDetayController : Controller
    {

        private readonly EnvanterContext _context;

        public SiparisDetayController(EnvanterContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int siparisId)
        {
            var list = await _context.SiparisDetaylars
                .Where(x => x.SiparisId == siparisId)
                .Include(x => x.Urun)
                .ToListAsync();

            return View(list);
        }

        // GET: Delete Onay Sayfası
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var siparisDetaylars = await _context.SiparisDetaylars
                .FirstOrDefaultAsync(m => m.SiparisDetayId == id);

            if (siparisDetaylars == null) return NotFound();

            return View(siparisDetaylars);
        }

        // POST: Gerçek Silme İşlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var siparisDetaylars = await _context.SiparisDetaylars.FindAsync(id);
            if (siparisDetaylars != null)
            {
                _context.SiparisDetaylars.Remove(siparisDetaylars);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}