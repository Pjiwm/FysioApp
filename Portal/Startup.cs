using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Portal
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
            services.AddScoped<IPatientRepository, DbPatientRepository>();

            services.AddScoped<UserManager<IdentityUser>>();
            services.AddScoped<SignInManager<IdentityUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();

            services.AddDbContext<FysioDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("default")));
            //services.AddSingleton<IPatientRepository, PatientRepository>();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZëË0123456789 ";
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = new PathString("/Auth/Login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(opts =>
            {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = true;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequirePhysicalTherapist",
                    policy => policy.RequireClaim("PhysicalTherapist"));
                options.AddPolicy("RequireEmployee", policy => policy.RequireClaim(ClaimTypes.Authentication, "Employee"));
                options.AddPolicy("RequireTherapist", policy => policy.RequireClaim(ClaimTypes.Authentication, "Therapist"));
                options.AddPolicy("RequirePatient", policy => policy.RequireClaim(ClaimTypes.Authentication, "Patient"));
            });



            services.AddControllersWithViews();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
