using Livraria.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Livraria.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Livraria.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.CrossCutting.DependeciesApp
{
    public static class DependenciesInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Sqlite");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
