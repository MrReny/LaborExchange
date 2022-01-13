using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreCustomUserManager.Data;
using FirebirdSql.Data.FirebirdClient;
using LaborExchange.Server.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;

namespace LaborExchange.Server
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            AppConfiguration = config;
        }

        public IConfiguration AppConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpContextAccessor();
            services.AddGrpc();
            services.AddMagicOnion();

            services.AddScoped<ContextMenuService>();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<Storage>(
                options => options.UseSqlite(this.Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddDbContext<LaborExchangeDbContext>(o =>
            {
                o.UseFirebird(new FbConnection( AppConfiguration.GetConnectionString("DefaultConnection")));
            });


            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.Cookie.Name = "AspNetCoreCustomUserManager";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                });



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                    {
                        options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    }
                );

            services.AddScoped<IUserManager, UserManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация
            app.UseCookiePolicy();

            app.UseMiddleware<BlazorCookieLoginMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");

                endpoints.MapMagicOnionService();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                //});
            });
        }
    }
}