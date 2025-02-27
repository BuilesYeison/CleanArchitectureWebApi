using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Inject AutoMapper & scan profiles
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
