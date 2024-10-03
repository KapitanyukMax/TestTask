using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TestTaskDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IIncidentsRepository, IncidentsRepository>();
        }
    }
}
