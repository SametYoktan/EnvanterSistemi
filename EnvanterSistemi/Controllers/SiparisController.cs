using EnvanterSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SiparisController : Controller
{
    private readonly EnvanterContext _context;
    public SiparisController(EnvanterContext context)
    {
        _context = context;
    }

    // Listeleme
    public async Task<IActionResult> Index()
    {
        var siparisler = await _context.Siparislers
            .Include(s => s.SiparisDetaylars)
                .ThenInclude(sd => sd.Urun)
            .ToListAsync();
        return View(siparisler);
    }


    // GET: Delete Onay Sayfası
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var siparis = await _context.Siparislers
            .FirstOrDefaultAsync(m => m.SiparisId == id);

        if (siparis == null) return NotFound();

        return View(siparis);
    }

    // POST: Gerçek Silme İşlemi
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var siparis = await _context.Siparislers.FindAsync(id);
        if (siparis != null)
        {
            _context.Siparislers.Remove(siparis);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}