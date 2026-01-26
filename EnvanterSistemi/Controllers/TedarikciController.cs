using EnvanterSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TedarikciController : Controller
{
    private readonly EnvanterContext _context;
    public TedarikciController(EnvanterContext context)
    {
        _context = context;
    }

    // Listeleme
    public async Task<IActionResult> Index()
    {
        var tedarikciler = await _context.Tedarikcilers.ToListAsync();
        return View(tedarikciler);
    }

    // Create
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Tedarikciler tedarikci)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tedarikci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tedarikci);
    }

    // Edit
    public async Task<IActionResult> Edit(int id)
    {
        var tedarikci = await _context.Tedarikcilers.FindAsync(id);
        if (tedarikci == null) return NotFound();
        return View(tedarikci);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Tedarikciler tedarikci)
    {
        if (id != tedarikci.TedarikciId) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(tedarikci);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tedarikci);
    }

    // GET: Delete Onay Sayfası
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var tedarikci = await _context.Tedarikcilers
            .FirstOrDefaultAsync(m => m.TedarikciId == id);

        if (tedarikci == null) return NotFound();

        return View(tedarikci);
    }

    // POST: Gerçek Silme İşlemi
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var tedarikci = await _context.Tedarikcilers.FindAsync(id);
        if (tedarikci != null)
        {
            _context.Tedarikcilers.Remove(tedarikci);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
