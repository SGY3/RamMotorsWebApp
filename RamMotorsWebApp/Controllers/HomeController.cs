using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RamMotorsWebApp.Data;
using RamMotorsWebApp.Models;
using RamMotorsWebApp.Models.ViewModels;
using System.Diagnostics;

namespace RamMotorsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var featurecars = _context.Car.Where(i => i.IsFeatured).OrderByDescending(c => c.Id).Take(8).ToList();

            var viewModel = new HomeViewModel
            {
                FeaturedCars = featurecars
            };
            return View(viewModel);
        }

        [Authorize]
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
