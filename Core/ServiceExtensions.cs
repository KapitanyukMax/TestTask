using Core.Interfaces;
using Core.MapperProfiles;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IContactsService, ContactsService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IIncidentsService, IncidentsService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppProfile));
        }
    }
}