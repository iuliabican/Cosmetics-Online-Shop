using Cosmetics_Online_Shop.Data;
using Cosmetics_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cosmetics_Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecificClassController : Controller
    {
        private ApplicationDbContext _db;
        public SpecificClassController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SpecificClass.ToList());
        }
        // GET Create Action Method
        public ActionResult Create()
        {
            return View();
        }

        // POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecificClass specificClass)
        {
            if (ModelState.IsValid)
            {
                _db.SpecificClass.Add(specificClass);
                await _db.SaveChangesAsync();
                TempData["save"] = "Specific Class has been saved";
                return RedirectToAction(nameof(Index));
            }
            return View(specificClass);
        }

        // GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var someSpecificClass = _db.SpecificClass.Find(id);
            if (someSpecificClass == null)
            {
                return NotFound();
            }
            return View(someSpecificClass);
        }

        // POST Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecificClass specificClass)
        {
            if (ModelState.IsValid)
            {
                _db.Update(specificClass);
                await _db.SaveChangesAsync();
                TempData["save"] = "Specific Class has been updated";
                return RedirectToAction(nameof(Index));
            }
            return View(specificClass);
        }

        // GET Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var someSpecificClass = _db.SpecificClass.Find(id);
            if (someSpecificClass == null)
            {
                return NotFound();
            }
            return View(someSpecificClass);
        }

        // POST Details Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecificClass cosmeticTypes)
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
            var someSpecificClass = _db.SpecificClass.Find(id);
            if (someSpecificClass == null)
            {
                return NotFound();
            }
            return View(someSpecificClass);
        }

        // POST Delete Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, SpecificClass specificClass)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != specificClass.Id)
            {
                return NotFound();
            }
            var someSpecificClass = _db.SpecificClass.Find(id);
            if (someSpecificClass == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(someSpecificClass);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Specific Class has been deleted";
                return RedirectToAction(nameof(Index));
            }
            return View(specificClass);
        }
    }
}
