using EnvanterSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnvanterSistemi.Controllers
{
    public class UrunlerController : Controller
    {

        private readonly EnvanterContext _context;

        public UrunlerController(EnvanterContext context)
        {
            _context = context;
        }

        // GET: Ürün Listeleme
        public async Task<IActionResult> Index()
        {
            var urunler = await _context.Urunlers
                .Include(u => u.Kategori)
                .Include(u => u.Tedarikci)
                .ToListAsync();
            return View(urunler);
        }

        // POST: TEST – Uyarı Göstermesep
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(List<Urunler> listurun)
        {
            var urunler = await _context.Urunlers
                .Include(u => u.Kategori)
                .Include(u => u.Tedarikci)
                .ToListAsync();

            ViewBag.Mesaj = "Sepetinize ürün başarıyla eklendi 🎉";

            return View(urunler);
        }
    }
}
