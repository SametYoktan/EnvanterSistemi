using EnvanterSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class KategoriController : Controller
{
    private readonly EnvanterContext _context;
    public KategoriController(EnvanterContext context)
    {
        _context = context;
    }

    // GET: Kategori
    public async Task<IActionResult> Index()
    {
        var list = await _context.Kategorilers.ToListAsync();
        return View(list);
    }

    // GET: Kategori/Create
    public IActionResult Create()
    {
        return View(new Kategoriler());
    }

    // POST: Kategori/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Kategoriler kategori)
    {
        if (!ModelState.IsValid) return View(kategori);

        _context.Kategorilers.Add(kategori);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Kategori/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var kategori = await _context.Kategorilers.FindAsync(id);
        if (kategori == null) return NotFound();
        return View(kategori);
    }

    // POST: Kategori/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Kategoriler kategori)
    {
        if (id != kategori.KategoriId) return NotFound();
        if (!ModelState.IsValid) return View(kategori);

        _context.Update(kategori);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Delete Onay Sayfası
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var kategori = await _context.Kategorilers
            .FirstOrDefaultAsync(m => m.KategoriId == id);

        if (kategori == null) return NotFound();

        return View(kategori);
    }

    // POST: Gerçek Silme İşlemi
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var kategori = await _context.Kategorilers.FindAsync(id);

        if (kategori != null)
        {
            _context.Kategorilers.Remove(kategori);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}