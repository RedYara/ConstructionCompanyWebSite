using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<WebDbContext>(option =>
            {
                option.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING"));
            });
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 0;
                options.Password.RequiredUniqueChars = 0;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<WebDbContext>();
            services.AddScoped<IWebDbContext>(provider =>
                provider.GetService<WebDbContext>());
            return services;
        }
    }
}
