using AssetManager.Core;
using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Core.Services;
using AssetManager.Infrastructure.Data;
using AssetManager.Infrastructure.Identity;
using AssetManager.Infrastructure.Logging;
using AssetManager.Web.Interfaces;
using AssetManager.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AssetManager.Web
{
    public class Startup
    {
        private IServiceCollection _services;
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

            services.AddDbContext<AssetManagerContext>(options =>
                options.UseInMemoryDatabase("assetmanager"));
            // Add Identity DbContext
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseInMemoryDatabase("Identity"));


            ConfigureServices(services);
        }

        // Configure services when the the app is running in demo environment
        // ( env value of "ASPNETCORE_ENVIRONMENT" is "Demo" )
        public void ConfigureDemoServices(IServiceCollection services)
        {
            // Use testing configuration as it use In-memory database
            // and we want in-memory database
            ConfigureTestingServices(services);
        }

        // This method gets called when Production Environment is used
        // Use this method to set Production services, like Production database
        public void ConfigureProductionServices(IServiceCollection services)
        {

            ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IStatusLabelService, StatusLabelService>();
            services.AddScoped<ISupplierViewModelService, SupplierViewModelService>();
            services.AddScoped<ILocationViewModelService, LocationViewModelService>();
            services.AddScoped<IDepreciationViewModelService, DepreciationViewModelService>();
            services.AddScoped<IManufacturerViewModelService, ManufacturerViewModelService>();
            services.AddScoped<IDepartmentsViewModelService, DepartmentsViewModelService>();
            services.AddScoped<ICategoryViewModelService, CategoryViewModelService>();
            services.AddScoped<IAssetModelViewModelService, AssetModelViewModelService>();
            services.AddScoped<IStatusLabelViewModelService, StatusLabelViewModelService>();
            services.Configure<ListSettings>(Configuration);
            services.AddSingleton<IUriComposer>(new UriComposer(Configuration.Get<ListSettings>()));

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddMemoryCache();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();

            _services = services;

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

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
