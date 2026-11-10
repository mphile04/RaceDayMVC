using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Services;
using RaceDayMVC.Models;

namespace RaceDayMVC.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly ApiService _apiService;

        public ParticipantController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Home()
        {
            if (HttpContext.Session.GetString("JWToken") == null) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BrowseEvents()
        {
            if (HttpContext.Session.GetString("JWToken") == null) return RedirectToAction("Login", "Account");

            try
            {
                // 1. Get the wrapped response from the API
                var response = await _apiService.GetAsync<EventListResponse>("events");

                // 2. Return the events list to the view
                if (response != null && response.Events != null)
                {
                    return View(response.Events);
                }

                return View(new List<EventViewModel>());
            }
            catch
            {
                return View(new List<EventViewModel>());
            }
        }
    }
}
