using System;
using FirebirdSql.Data.FirebirdClient;
using LaborExchange.Server.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddDbContext<LaborExchangeDbContext>(o =>
            {
                o.UseFirebird(new FbConnection(AppConfiguration.GetConnectionString("DefaultConnection")));
            });

            services.AddSingleton<IUserRepo, UserRepo>();

            services.AddScoped<IUserManager, UserManager>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => { options.ExpireTimeSpan = TimeSpan.FromDays(7); }
                );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication(); // аутентификация
            app.UseAuthorization(); // авторизация
            app.UseCookiePolicy();

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