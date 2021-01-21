using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingServiceStores.Areas.Identity;
using ParkingServiceStores.Data;
using ParkingServiceStores.Data.DTOModels;
using ParkingServiceStores.Data.Models;
using ParkingServiceStores.Data.Repositories;
using Syncfusion.Blazor;

namespace ParkingServiceStores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<DebtAmountCalculator>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CarDto, Car>()
                    .ForPath(c => c.Owner.Name, opt => opt.MapFrom(c => c.OwnerName))
                    .ForPath(c => c.Owner.PhoneNumber, opt => opt.MapFrom(c => c.OwnerPhoneNumber))
                    .ForPath(c=>c.Owner.Id, opt=>opt.MapFrom(c=>c.OwnerId)).ReverseMap());
            services.AddSingleton(config.CreateMapper());
            services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzgzOTkxQDMxMzgyZTM0MmUzMEVxNElNT1RPbHZuKzRqaWtDWjBNWWpxc2t5cWErOWtpZkVLb0NDZ0kxYkk9");
            services.AddTransient<IRepository<Car>, CarRepository>();
            services.AddTransient<IRepository<Debt>, DebtRepository>();
            services.AddTransient<IRepository<Price>, PriceRepository>();
            services.AddTransient<IRepository<JournalRecord>, JournalRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
