using Microsoft.AspNetCore.Mvc.RazorPages;
using SubscriptionApp.Services;

namespace SubscriptionApp.Views.Home
{
    public class IndexModel : PageModel
    {
        private readonly ServiceRepository _serviceRepository;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ServiceRepository serviceRepository, ILogger<IndexModel> logger)
        {
            _serviceRepository = serviceRepository;
            _logger = logger;
        }

        public List<SubscriptionApp.Models.Service> Services { get; set; } = new List<SubscriptionApp.Models.Service>(); // Инициализация

        public void OnGet(string searchQuery)
        {
            Services = _serviceRepository.SearchServices(searchQuery ?? string.Empty); // Обработка null
            _logger.LogInformation("Loaded services with search query: {SearchQuery}", searchQuery ?? "none");
        }
    }
}