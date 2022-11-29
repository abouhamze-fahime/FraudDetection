using Fraud.Services;
using Fraud.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fraud.Convertor;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;
using Fraud.Infrastructure.Cache;
using Microsoft.Extensions.Logging;

namespace Fraud
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

            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            #region Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(432000);
            });
            #endregion

            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            });

            #region DataBase Context
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            #endregion

            #region Ioc  
            services.AddTransient<IServices, Fraud.Services.Services>();
            services.AddSingleton<ICacheProvider, CacheProvider>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFireServices, FireServices>();
            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddTransient<IPermissionService, PermissionService>();
            #endregion



            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            , ILoggerFactory loggerFactory


            )
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // loggerFactory.AddLog4Net();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseAuthorization();
            //app.Use(next => async context =>
            //{
            //    var path = context.Request.Path.Value;
            //    if (!context.User.Identity.IsAuthenticated && path != null && !path.ToLower().Contains("login"))
            //        context.Response.Redirect("/Login?ReturnUrl=" + UrlEncoder.Default.Encode(path));
            //    await next(context);
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
                endpoints.MapRazorPages();
            });
        }
    }
}
