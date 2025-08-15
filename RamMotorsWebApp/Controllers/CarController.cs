using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RamMotorsWebApp.Data;
using RamMotorsWebApp.Models;
using RamMotorsWebApp.Models.ViewModels;
using RamMotorsWebApp.Services;

namespace RamMotorsWebApp.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        private readonly MailService _mailService;

        public CarController(AppDbContext context, MailService mailService)
        {
            _context = context;
            _mailService = mailService;
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
        [HttpPost]
        public async Task<IActionResult> SendRequestDetails(int CarId, string Name, string Phone, string Email, string Message)
        {
            var car = _context.Car.FirstOrDefault(c => c.Id == CarId);
            if (car == null)
                return NotFound();

            // Save to DB (optional)
            var request = new CarRequest
            {
                CarId = CarId,
                Name = Name,
                Phone = Phone,
                Email = Email,
                Message = Message,
                RequestDate = DateTime.Now
            };
            _context.CarRequests.Add(request);
            _context.SaveChanges();

            // Send email to support team
            await _mailService.SendRequestDetailsEmailAsync(Name, Phone, Email, Message, car.Title);

            TempData["Success"] = "Your request has been sent! Our team will contact you shortly.";
            return RedirectToAction("Details", new { id = CarId });
        }
    }
}
