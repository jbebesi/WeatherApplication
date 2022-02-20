using WeatherApplication.Server.Data;
using WeatherApplication.Server.interfaces;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.Services
{
    public class SubscriptionHelper : ISubscriptionHelper
    {
        private readonly ILogger<SubscriptionHelper> _logger;
        private readonly ApplicationDbContext _dbContext;

        public SubscriptionHelper(ILogger<SubscriptionHelper> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsersAsync()
        {
            var users = _dbContext.Users.ToList();
            return await Task.FromResult( users);
        }
    }
}
