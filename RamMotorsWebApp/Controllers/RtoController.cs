using Microsoft.AspNetCore.Mvc;
using RamMotorsWebApp.Data;
using RamMotorsWebApp.Models;
using RamMotorsWebApp.Services;

namespace RamMotorsWebApp.Controllers
{
    public class RtoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly MailService _mailService;
        public RtoController(AppDbContext context, MailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Submit(RtoRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            _context.RtoRequests.Add(model);
            await _context.SaveChangesAsync();

            await _mailService.SendDetailsEmailAsync(
                model.Name,
                model.Phone,
                model.Email,
                $"Service: {model.ServiceType}\nVehicle: {model.VehicleNumber}\n\n{model.Message}",
                "RTO Service Request"
            );

            TempData["Success"] = "Your RTO request has been submitted. Our team will contact you soon.";
            return RedirectToAction("Index");
        }
    }
}
