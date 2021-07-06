using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoftToyShop.Seeder;
using SoftToyShop.Repository.Services;
using SoftToyShop.Repository.Services.Interfaces;
using SoftToyShop.Repository.Models;
using SoftToyShop.Middlewares;

namespace SoftToyShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SoftToyShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly("SoftToyShop")));

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<SoftToyShopDbContext>();

            services.AddScoped<SoftToySeeder>();
            services.AddControllersWithViews();

            services.AddScoped<RequestTimeMiddleware>();
            services.AddScoped<ISoftToyRepository, SoftToyRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(ShoppingCart.GetCart);
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SoftToySeeder softToySeeder)
        {
            softToySeeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseMiddleware<RequestTimeMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
