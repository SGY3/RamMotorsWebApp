using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RamMotorsWebApp.Data;
using RamMotorsWebApp.Models.ViewModels;

namespace RamMotorsWebApp.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var featurecars = await _context.Car.OrderByDescending(c => c.Id).ToListAsync();

            var viewModel = new HomeViewModel
            {
                FeaturedCars = featurecars
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var car = await _context.Car.FirstOrDefaultAsync(i => i.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
    }
}
