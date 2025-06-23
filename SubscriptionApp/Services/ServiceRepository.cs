using SubscriptionApp.Data;
using SubscriptionApp.Models;
using System;

namespace SubscriptionApp.Services
{
    public class ServiceRepository
    {
        private readonly SubscriptionDbContext _context;

        public ServiceRepository(SubscriptionDbContext context)
        {
            _context = context;
            SeedData();
        }

        private void SeedData()
        {
            if (!_context.Services.Any())
            {
                var services = new List<Service>
                {
                    new Service { Name = "Spotify", Description = "Музыкальный стриминговый сервис", Price = 9.99m },
                    new Service { Name = "Netflix", Description = "Видео стриминговый сервис", Price = 13.99m },
                    new Service { Name = "YouTube Premium", Description = "Видео и музыка без рекламы", Price = 11.99m },
                    new Service { Name = "Disney+", Description = "Семейные фильмы и сериалы", Price = 7.99m },
                    new Service { Name = "Amazon Prime", Description = "Видео, музыка и доставка", Price = 5.99m },
                    new Service { Name = "Hulu", Description = "Американский стриминговый сервис", Price = 6.99m }
                };
                _context.Services.AddRange(services);
                _context.SaveChanges();
                Console.WriteLine("SeedData executed, added 6 services.");
            }
        }

        public List<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public List<Service> SearchServices(string query)
        {
            if (string.IsNullOrEmpty(query))
                return _context.Services.ToList();

            return _context.Services
                .Where(s => s.Name.ToLower().Contains(query.ToLower()))
                .ToList();
        }

        public void AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void RemoveService(int id)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}