using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Server.Models;

namespace WeatherApplication.Server.interfaces
{
    public interface ISubscriptionHelper
    {
        public Task<IEnumerable<ApplicationUser>> GetApplicationUsersAsync();
    }
}
