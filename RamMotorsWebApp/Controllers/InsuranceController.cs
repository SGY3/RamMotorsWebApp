using Microsoft.AspNetCore.Mvc;
using RamMotorsWebApp.Models.ViewModels;
using RamMotorsWebApp.Services;

namespace RamMotorsWebApp.Controllers
{
    public class InsuranceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Inquiry(InsuranceInquiryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please fill all required fields.");

            string htmlBody = $@"
            <h2>Insurance Inquiry</h2>
            <p><strong>Name:</strong> {model.Name}</p>
            <p><strong>Email:</strong> {model.Email}</p>
            <p><strong>Phone:</strong> {model.Phone}</p>
            <p><strong>Insurance Type:</strong> {model.InsuranceType}</p>
            <p><strong>Message:</strong> {model.Message}</p>
        ";

            //await _emailService.SendEmailAsync("support@rammotors.com", "New Insurance Inquiry", htmlBody);

            return RedirectToAction("Index", new { success = true });
        }
    }
}
