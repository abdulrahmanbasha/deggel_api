using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bknsystem.privateApi.Interfaces;
using bknsystem.privateApi.Models;
using bknsystem.privateApi.Repositories;
using bknsystem.privateApi.Services;
using martisoor.privateApi_master.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace bknsystem.privateApi
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
            services.Configure<HotelDatabaseSettings>(
                Configuration.GetSection(nameof(HotelDatabaseSettings)));

            services.AddSingleton<IHotelDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<HotelDatabaseSettings>>().Value);

            services.AddScoped<HotelService>();
            services.AddScoped<HotelServiceMobile>();

            services.AddControllers()
               .AddNewtonsoftJson(options => options.UseMemberCasing());
            services.AddControllers();
            services.AddDbContext<Datalayer>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Register the Swagger services
            services.AddSwaggerDocument();
            Mapper.Reset();
            services.AddAutoMapper();

            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthorization();

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });


        }
    }
}
