using Microsoft.AspNetCore.Mvc;

namespace EnvanterSistemi.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
