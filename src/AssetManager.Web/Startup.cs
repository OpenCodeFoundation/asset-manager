using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            //services.AddDbContext<AcademiaContext>(options =>
            //    options.UseInMemoryDatabase("academia"));

            //ConfigureServices(services);
        }

        // This method gets called when Production Environment is used
        // Use this method to set Production services, like Production database
        public void ConfigureProductionServices(IServiceCollection services)
        {
            //services.AddDbContext<AcademiaContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            //);

            //ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

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
