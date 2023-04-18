﻿using Diploma.Application;
using Diploma.Application.Common.Mappings;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Diploma.Persistence

namespace Diploma.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(Diploma.Application.DependencyInjection).Assembly));
            });

            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddControllersWithViews();

            services.AddOptions();
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = $"/Account/Login";
            //    options.LogoutPath = $"/Account/Logout";
            //    options.AccessDeniedPath = $"/Account/AccessDenied";
            //});

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/v2/Web/App/Index";
                    await next();
                }
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                DbInitializer.Initialize(serviceScope);
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=App}/{action=Index}/{id?}");

            });
        }
    }
}
