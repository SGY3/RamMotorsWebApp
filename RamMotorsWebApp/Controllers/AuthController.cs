using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RamMotorsWebApp.Data;
using RamMotorsWebApp.Models;
using System.Security.Claims;

namespace RamMotorsWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Registration registration)
        {
            ApplicationUser user = new()
            {
                UserName = registration.Email,
                Email = registration.Email,
                NormalizedEmail = registration.Email.ToUpper(),
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                PhoneNumber = registration.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registration.Password);
            if (result.Succeeded)
            {
                bool status = await AssignRole(registration.Email, "Customer");
                if (status)
                {
                    TempData["SuccessMessage"] = "Registration Successful";
                    RedirectToAction(nameof(Login));
                }
                else
                {
                    TempData["ErroMessage"] = "Something went wrong while assigning the role";
                }
            }
            else
            {
                TempData["ErroMessage"] = result.Errors.FirstOrDefault().Description;
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequest.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (user == null || isValid == false)
            {
                return View();
            }
            else
            {
                //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                //identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                //identity.AddClaim(new Claim(ClaimTypes.Role, "Customer"));

                //var principal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            string? role = User.FindFirstValue(ClaimTypes.Role);
            //await HttpContext.SignOutAsync();
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
