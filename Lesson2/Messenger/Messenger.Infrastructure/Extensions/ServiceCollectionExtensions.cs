using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Messenger.Domain;
using Messenger.Infrastructure.Context;
using Messenger.Infrastructure.Managers;

namespace Messenger.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddManagers();
            services.AddDatabase(configuration);
            return services;
        }
        private static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            return services;
        }
        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserContext>(builder =>
                builder.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
