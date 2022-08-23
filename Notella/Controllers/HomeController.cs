using Microsoft.AspNetCore.Mvc;
using Notella.Models;
using System.Diagnostics;
using Notella.Repositories;
using Notella.Contracts;

namespace Notella.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBaseRepository<Notes> _repo;

        public HomeController(IBaseRepository<Notes> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _repo.GetAll();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var query = await _repo.GetOne(id);
            return View(query);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Notes obj)
        {
            if (!ModelState.IsValid)
                return View(obj);
  
            await _repo.Create(obj);
            TempData["success"] = "Note added.";
            return RedirectToAction("Index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(Notes obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            await _repo.Update(obj.Id, new { obj.Title, obj.Content });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}