using Microsoft.AspNetCore.Mvc;
using SubscriptionApp.Services;

namespace SubscriptionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceRepository _serviceRepository;

        public HomeController(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IActionResult Index(string searchQuery)
        {
            var services = _serviceRepository.SearchServices(searchQuery);
            return View(services);
        }
    }
}