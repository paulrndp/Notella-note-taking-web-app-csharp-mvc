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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Notes obj)
        {
            if (!ModelState.IsValid)
                return View(obj);
            await _repo.Create(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}