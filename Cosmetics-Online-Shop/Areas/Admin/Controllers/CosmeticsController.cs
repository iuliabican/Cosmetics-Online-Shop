using Cosmetics_Online_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cosmetics_Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CosmeticsController : Controller
    {
        private ApplicationDbContext _db;

        public CosmeticsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Cosmetics.Include(c=>c.CosmeticTypes).Include(s=>s.SpecificClass).ToList());
        }
    }
}
