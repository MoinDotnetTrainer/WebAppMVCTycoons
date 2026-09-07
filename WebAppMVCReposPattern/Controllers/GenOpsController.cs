using DataAccessLayer.Irepo;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCReposPattern.Controllers
{
    public class GenOpsController : Controller
    {
        private readonly InterfacGeneric<GenModel> _repo;

        public GenOpsController(InterfacGeneric<GenModel> repo)
        {
            _repo = repo;
        }

        // GET: /Products
        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetAllAsync();
            return View(products);
        }

        // GET: /Products/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // GET: /Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenModel product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _repo.AddAsync(product);
            await _repo.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: /Products/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GenModel product)
        {
           

            if (!ModelState.IsValid)
                return View(product);

            var existingProduct = await _repo.GetByIdAsync(id);

            if (existingProduct == null)
                return NotFound();

            _repo.Update(product);
            await _repo.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: /Products/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            _repo.Delete(product);
            await _repo.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
