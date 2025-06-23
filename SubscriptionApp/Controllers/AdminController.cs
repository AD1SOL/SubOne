using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionApp.Models;
using SubscriptionApp.Services;

namespace SubscriptionApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ServiceRepository _serviceRepository;

        public AdminController(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IActionResult Index()
        {
            var services = _serviceRepository.GetAllServices();
            return View(services);
        }

        [HttpPost]
        public IActionResult Add(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceRepository.AddService(service);
                return RedirectToAction("Index");
            }
            return View("Index", _serviceRepository.GetAllServices());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _serviceRepository.RemoveService(id);
            return RedirectToAction("Index");
        }
    }
}