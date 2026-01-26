using EnvanterSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UrunController : Controller
{
    private readonly EnvanterContext _context;
    public UrunController(EnvanterContext context)
    {
        _context = context;
    }

    // Listeleme
    public async Task<IActionResult> Index()
    {
        var urunler = await _context.Urunlers
            .Include(u => u.Kategori)
            .Include(u => u.Tedarikci)
            .ToListAsync();
        return View(urunler);
    }

    // Create - GET
    public IActionResult Create()
    {
        ViewBag.Kategoriler = _context.Kategorilers.ToList();
        ViewBag.Tedarikciler = _context.Tedarikcilers.ToList();
        return View();
    }

    // Create - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Urunler urun)
    {
        if (ModelState.IsValid)
        {
            _context.Add(urun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Kategoriler = _context.Kategorilers.ToList();
        ViewBag.Tedarikciler = _context.Tedarikcilers.ToList();
        return View(urun);
    }

    // Edit - GET
    public async Task<IActionResult> Edit(int id)
    {
        var urun = await _context.Urunlers.FindAsync(id);
        if (urun == null) return NotFound();

        ViewBag.Kategoriler = _context.Kategorilers.ToList();
        ViewBag.Tedarikciler = _context.Tedarikcilers.ToList();
        return View(urun);
    }

    // Edit - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Urunler urun)
    {
        if (id != urun.UrunId) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(urun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Kategoriler = _context.Kategorilers.ToList();
        ViewBag.Tedarikciler = _context.Tedarikcilers.ToList();
        return View(urun);
    }

    // GET: Delete Onay Sayfası
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var urunler = await _context.Urunlers
            .FirstOrDefaultAsync(m => m.UrunId == id);

        if (urunler == null) return NotFound();

        return View(urunler);
    }

    // POST: Gerçek Silme İşlemi
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var urun = await _context.Urunlers.FindAsync(id);
        if (urun != null)
        {
            _context.Urunlers.Remove(urun);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}