using Diploma.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DiplomaDbContext>(option =>
            {
                option.UseNpgsql(connectionString);
            });
            services.AddIdentityCore<IdentityUser>(option => { }).AddDefaultTokenProviders().AddEntityFrameworkStores<DiplomaDbContext>();
            services.AddScoped<IDiplomaDbContext>(provider =>
                provider.GetService<DiplomaDbContext>());
            return services;
        }
    }
}
