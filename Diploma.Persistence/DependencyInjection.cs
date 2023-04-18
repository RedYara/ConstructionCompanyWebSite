using Diploma.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DiplomaDbContext>(option =>
            {
                option.UseNpgsql(connectionString);
            });
            services.AddScoped<IDiplomaDbContext>(provider =>
                provider.GetService<DiplomaDbContext>());
            return services;
        }
    }
}
