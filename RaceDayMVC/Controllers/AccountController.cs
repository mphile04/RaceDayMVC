using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService _apiService;

        public AccountController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var response = await _apiService.PostAsync<AuthResponse>("auth/login", new { model.Email, model.Password });

                if (response != null && response.Success)
                {
                    HttpContext.Session.SetString("JWToken", response.Token!);
                    HttpContext.Session.SetString("UserRole", response.Role!);
                    HttpContext.Session.SetString("UserEmail", response.Email!);

                    if (response.Role == "Organiser")
                        return RedirectToAction("Dashboard", "Organiser");
                    else
                        return RedirectToAction("Home", "Participant");
                }
                ViewBag.Error = response?.Message ?? "Login failed";
            }
            catch (Exception ex)
            {
                // Show the exact error on the screen
                ViewBag.Error = "Login error: " + ex.Message;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var payload = new
                {
                    model.Email,
                    model.Password,
                    model.Role,
                    model.FullName,
                    model.IDNumber,
                    model.PhoneNumber,
                    model.OrganisationName,
                    model.RegistrationNumber,
                    model.ContactPerson
                };

                var response = await _apiService.PostAsync<AuthResponse>("auth/register", payload);

                if (response != null && response.Success)
                {
                    TempData["Success"] = "Registration successful. Please log in.";
                    return RedirectToAction("Login");
                }
                ViewBag.Error = response?.Message ?? "Registration failed";
            }
            catch (Exception ex)
            {
                // Show the exact error on the screen
                ViewBag.Error = "Registration error: " + ex.Message;
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}