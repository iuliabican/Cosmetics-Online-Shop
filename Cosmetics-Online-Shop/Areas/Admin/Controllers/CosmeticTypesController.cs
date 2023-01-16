using Cosmetics_Online_Shop.Data;
using Cosmetics_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cosmetics_Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CosmeticTypesController : Controller
    {
        private ApplicationDbContext _db;

        public CosmeticTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var data = _db.CosmeticTypes.ToList();
            return View(_db.CosmeticTypes.ToList());
        }

        // GET Create Action Method
        public ActionResult Create()
        {
            return View();
        }

        // POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CosmeticTypes cosmeticTypes)
        {
            if (ModelState.IsValid)
            {
                _db.CosmeticTypes.Add(cosmeticTypes);
                await _db.SaveChangesAsync();
                TempData["save"]="Cosmetic Type has been saved";
                return RedirectToAction(nameof(Index));
            }
            return View(cosmeticTypes);
        }

        // GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cosmeticType = _db.CosmeticTypes.Find(id);
            if(cosmeticType == null)
            {
                return NotFound();
            }
            return View(cosmeticType);
        }

        // POST Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CosmeticTypes cosmeticTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(cosmeticTypes);
                await _db.SaveChangesAsync();
                TempData["save"] = "Cosmetic Type has been updated";
                return RedirectToAction(nameof(Index));
            }
            return View(cosmeticTypes);
        }

        // GET Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cosmeticType = _db.CosmeticTypes.Find(id);
            if (cosmeticType == null)
            {
                return NotFound();
            }
            return View(cosmeticType);
        }

        // POST Details Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(CosmeticTypes cosmeticTypes)
        {
            return RedirectToAction(nameof(Index));

        }

        // GET Delete Action Method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cosmeticType = _db.CosmeticTypes.Find(id);
            if (cosmeticType == null)
            {
                return NotFound();
            }
            return View(cosmeticType);
        }

        // POST Delete Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, CosmeticTypes cosmeticTypes)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != cosmeticTypes.Id)
            {
                return NotFound();
            }
            var cosmeticType = _db.CosmeticTypes.Find(id);
            if(cosmeticType==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(cosmeticType);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Cosmetic Type has been deleted";
                return RedirectToAction(nameof(Index));
            }
            return View(cosmeticTypes);
        }
    }
}
