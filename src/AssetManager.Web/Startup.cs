using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Core.Interfaces;
using AssetManager.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AssetManager.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called when Development Environment is used
        // Use this method to set Development services, like Development database
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memeory databses
            ConfigureTestingServices(services);

            // use real database
            // ConfigureProductionService(services);
        }

        // This method gets called when Testing Environment is used
        // Use this method to set Testing services, like Testng database
        public void ConfigureTestingServices(IServiceCollection services)
        {
            // Configure in-memory database
            services.AddDbContext<AssetManagerContext>(options =>
                options.UseInMemoryDatabase("assetmanager"));

            ConfigureServices(services);
        }

        // This method gets called when Production Environment is used
        // Use this method to set Production services, like Production database
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<AssetManagerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
